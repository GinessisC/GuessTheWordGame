using GuessWordGames;
using System.Collections;

namespace GuessWordGame.Test;
public class GuessWordGameTest
{
    private const string wrongAnswereResponse = "is incorrect! Try again!";
    private const string rightAnswereResponse = "You have guessed the word!";

    [Theory]
    [InlineData("not true word")]
    [InlineData("happy")]
    [InlineData("Random")]

    public void SetUpGuessGame_InputWord_WorngAnswers(string inputWord)
    {
        //Arrange
        GuessWordGames.GuessWordGame guessWordGame = new();

        //Act
        string resultOfGuessGame = guessWordGame.GetResultOfGuessGame(inputWord);

        //Assert
        Assert.Contains(wrongAnswereResponse, resultOfGuessGame);
    }

    [Theory]
    [InlineData("words")]
    [InlineData("mmm")]
    [InlineData("test")]
    public void SetUpGuessGame_InputWord_RightAnswers(string inputWord)
    {
        //Arrange
        GuessWordGames.GuessWordGame guessWordGame = new(inputWord);

        //Act
        string resultOfGuessGame = guessWordGame.GetResultOfGuessGame(inputWord);

        //Assert
        Assert.Contains(rightAnswereResponse, resultOfGuessGame);
    }
}