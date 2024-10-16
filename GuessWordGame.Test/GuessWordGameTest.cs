using GuessWordGames.Models;
using System.Collections;
using NSubstitute;
using GuessWordGames.Interfaces;

namespace GuessWordGames.Test;
public class GuessWordGameTest
{
    private const string wrongAnswereResponse = "is incorrect! Try again!";
    private const string rightAnswereResponse = "You have guessed the word!";


    public void M()
    {
        var calculator = Substitute.For<IUserInterface>();
    }
    

    //[Theory]
    //[InlineData("not true word")]
    //[InlineData("happy")]
    //[InlineData("Random")]

    //public void SetUpGuessGame_InputWord_WorngAnswers(string inputWord)
    //{
    //    //Arrange
    //    GuessWordGame guessWordGame = new();

    //    //Act
    //    string resultOfGuessGame = guessWordGame.SetUpGuessGame(inputWord);

    //    //Assert
    //    Assert.Contains(wrongAnswereResponse, resultOfGuessGame);
    //}

    //[Theory]
    //[InlineData("wordsList")]
    //[InlineData("mmm")]
    //[InlineData("test")]
    //public void SetUpGuessGame_InputWord_RightAnswers(string inputWord)
    //{
    //    //Arrange
    //    GuessWordGame guessWordGame = new(inputWord);

    //    //Act
    //    string resultOfGuessGame = guessWordGame.SetUpGuessGame(inputWord);

    //    //Assert
    //    Assert.Contains(rightAnswereResponse, resultOfGuessGame);
    //}
}