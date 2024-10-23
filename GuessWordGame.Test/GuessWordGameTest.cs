using GuessWordGames.Models;
using System.Collections;
using NSubstitute;
using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.RandomModules;
using System.ComponentModel;

namespace GuessWordGames.Test;
public class GuessWordGameTest
{
    private static int _guessedWordIndex = 2;
    private static int _nonGuessedWordIndex = 0;

    private static List<Word> _wordsValues = new List<Word>()
    {
        new Word("test"),
        new Word("value"),
        new Word("was added")

    };
    private static WordsCollection _words = new(_wordsValues);

    [Fact]
    [DisplayName("not successful attempt where input word in lower")]
    public void NonSuccessfulCase()
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        var randomProvider = Substitute.For<IRandomProvider>();
        var messagesDisplayer = Substitute.For<IGameMessagesDisplayer>();

        var randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(_nonGuessedWordIndex);
        userInterface.GetWordsToGuess().Returns(_words);
        userInterface.GetUserWordAttempt().Returns(_wordsValues[_nonGuessedWordIndex]);
        messagesDisplayer.AskIsContinue().Returns(false);

        GuessGameSessionsHandler sessionsHandler = new(userInterface, messagesDisplayer, randomProvider);
        //Act

        sessionsHandler.SetUpGamePool();
        //Assert
        userInterface.Received(1).WhenWordIsBelow(_wordsValues[_guessedWordIndex]);
        userInterface.Received(1).GetUserWordAttempt();
        userInterface.DidNotReceive().WhenWordIsAbove(_wordsValues[_guessedWordIndex]);
        userInterface.DidNotReceive().WhenWordIsNotFound(_wordsValues[_guessedWordIndex]);
        userInterface.DidNotReceive().WhenWordIsGuessed(_wordsValues[_guessedWordIndex]);


    }

    [Fact]
    [DisplayName("successful attempt: 1 try")]
    public void SuccessfulCase()
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        var randomProvider = Substitute.For<IRandomProvider>();
        var messagesDisplayer = Substitute.For<IGameMessagesDisplayer>();

        var randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(_guessedWordIndex);
        userInterface.GetWordsToGuess().Returns(_words);
        userInterface.GetUserWordAttempt().Returns(_wordsValues[_guessedWordIndex]);
        messagesDisplayer.AskIsContinue().Returns(false);

        GuessGameSessionsHandler sessionsHandler = new(userInterface, messagesDisplayer, randomProvider);
        //Act

        sessionsHandler.SetUpGamePool();
        //Assert
        userInterface.Received(1).GetWordsToGuess();
        userInterface.Received(1).GetUserWordAttempt();
        userInterface.DidNotReceive().WhenWordIsAbove(_wordsValues[_guessedWordIndex]);
        userInterface.DidNotReceive().WhenWordIsBelow(_wordsValues[_guessedWordIndex]);
        userInterface.DidNotReceive().WhenWordIsNotFound(_wordsValues[_guessedWordIndex]);
    }

    [Fact]
    [DisplayName("To test messages displaying")]
    public void DisplayGameMessages()
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        var randomProvider = Substitute.For<IRandomProvider>();
        var messagesDisplayer = Substitute.For<IGameMessagesDisplayer>();

        var randomNum = randomProvider.Next(0, _wordsValues.Count - 1).Returns(_guessedWordIndex);
        messagesDisplayer.AskIsContinue().Returns(false);
        userInterface.GetWordsToGuess().Returns(_words);
        userInterface.GetUserWordAttempt().Returns(_wordsValues[_guessedWordIndex]);

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