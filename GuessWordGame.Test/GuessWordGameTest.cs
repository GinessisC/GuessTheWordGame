using System.ComponentModel;
using GuessWordGames.Interfaces;
using GuessWordGames.Models;
using GuessWordGames.Models.Components;
using NSubstitute;

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
		IGameMessagesDisplay? gameMessagesDisplayed = Substitute.For<IGameMessagesDisplay>();

		randomProvider.Next(0, _wordsValues.Count - 1).Returns(NonGuessedWordIndex);
		userInterface.GetWordsToGuess().Returns(_words);
		userInterface.GetUserWordAttempt().Returns(_wordsValues[NonGuessedWordIndex]);
		gameMessagesDisplayed.AskIsContinue().Returns(false);

		GuessWordGameSession session = new(userInterface, randomProvider);

		//Act
		session.LaunchGame();

		//Assert
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
		IGameMessagesDisplay? messagesDisplayed = Substitute.For<IGameMessagesDisplay>();

		userInterface.GetWordsToGuess().Returns(_words);
		userInterface.GetUserWordAttempt().Returns(_wordsValues[GuessedWordIndex]);
		messagesDisplayed.AskIsContinue().Returns(false);

		GuessWordGameSession session = new(userInterface, randomProvider);

		//Act

		session.LaunchGame();

		//Assert
		userInterface.Received(1).GetWordsToGuess();
		userInterface.Received(1).GetUserWordAttempt();
		userInterface.DidNotReceive().WhenWordIsAbove(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsBelow(_wordsValues[GuessedWordIndex]);
		userInterface.DidNotReceive().WhenWordIsNotFound(_wordsValues[GuessedWordIndex]);
	}
}