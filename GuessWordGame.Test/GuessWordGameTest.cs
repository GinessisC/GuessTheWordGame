using System.ComponentModel;
using GuessWordGames.Interfaces;
using GuessWordGames.Models;
using GuessWordGames.Models.Components;
using NSubstitute;
using NSubstitute.Core;

namespace GuessWordGame.Test;

public class GuessWordGameTest
{
	private const int GuessedWordIndex = 2;
	private const int NonGuessedWordIndex = 0;

	private static readonly List<Word> _wordsValues =
	[
		new("test"),
		new("value"),
		new("was added")
	];

	private static readonly WordsCollection _words = new(_wordsValues);

	[Fact]
	[DisplayName("not successful attempt where input word in lower")]
	public void NonSuccessfulCase()
	{
		//Arrange
		IUserInterface? userInterface = Substitute.For<IUserInterface>();
		IRandomProvider? randomProvider = Substitute.For<IRandomProvider>();
		IGameMessagesDisplay? gameMessagesDisplayer = Substitute.For<IGameMessagesDisplay>();
		
		ConfiguredCall? randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(NonGuessedWordIndex);
		userInterface.GetWordsToGuess().Returns(_words);
		userInterface.GetUserWordAttempt().Returns(_wordsValues[NonGuessedWordIndex]);
		gameMessagesDisplayer.AskIsContinue().Returns(false);

		GuessGameSessionsHandler sessionsHandler = new(userInterface, gameMessagesDisplayer, randomProvider);

		//Act

		sessionsHandler.SetUpGamePool();

		//Assert
		userInterface.Received(1).WhenWordIsBelow(_wordsValues[GuessedWordIndex]);
		userInterface.Received(1).GetUserWordAttempt();
		userInterface.DidNotReceive().WhenWordIsAbove(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsNotFound(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsGuessed(_wordsValues[GuessedWordIndex]);
	}

	[Fact]
	[DisplayName("successful attempt: 1 try")]
	public void SuccessfulCase()
	{
		//Arrange
		IUserInterface? userInterface = Substitute.For<IUserInterface>();
		IRandomProvider? randomProvider = Substitute.For<IRandomProvider>();
		IGameMessagesDisplay? messagesDisplayer = Substitute.For<IGameMessagesDisplay>();

		ConfiguredCall? randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(GuessedWordIndex);
		userInterface.GetWordsToGuess().Returns(_words);
		userInterface.GetUserWordAttempt().Returns(_wordsValues[GuessedWordIndex]);
		messagesDisplayer.AskIsContinue().Returns(false);

		GuessGameSessionsHandler sessionsHandler = new(userInterface, messagesDisplayer, randomProvider);

		//Act

		sessionsHandler.SetUpGamePool();

		//Assert
		userInterface.Received(1).GetWordsToGuess();
		userInterface.Received(1).GetUserWordAttempt();
		userInterface.DidNotReceive().WhenWordIsAbove(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsBelow(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsNotFound(_wordsValues[GuessedWordIndex]);
	}

	[Fact]
	[DisplayName("To test messages displaying")]
	public void DisplayGameMessages()
	{
		//Arrange
		IUserInterface? userInterface = Substitute.For<IUserInterface>();
		IRandomProvider? randomProvider = Substitute.For<IRandomProvider>();
		IGameMessagesDisplay? messagesDisplayer = Substitute.For<IGameMessagesDisplay>();

		ConfiguredCall? randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(GuessedWordIndex);
		messagesDisplayer.AskIsContinue().Returns(false);
		userInterface.GetWordsToGuess().Returns(_words);
		userInterface.GetUserWordAttempt().Returns(_wordsValues[GuessedWordIndex]);

		GuessGameSessionsHandler sessionsHandler = new(userInterface, messagesDisplayer, randomProvider);

		//Act
		sessionsHandler.SetUpGamePool();

		//Assert
		messagesDisplayer.Received(1).ShowGreetMessage();
		messagesDisplayer.Received(1).ShowExitMessage();

		//userInterface.Received(1).GetWordsToGuess();
		//userInterface.Received(1).GetUserWordAttempt();
	}
}