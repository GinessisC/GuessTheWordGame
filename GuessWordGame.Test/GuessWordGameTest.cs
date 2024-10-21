using GuessWordGames.Models;
using System.Collections;
using NSubstitute;
using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;

namespace GuessWordGames.Test;
public class GuessWordGameTest
{
    [Theory]
    [InlineData("test")]
    public void GetUserWordAttempt_word_(string word)
    {
        //Arrange
        var userInterface = Substitute.For<IUserInterface>();
        
        //Act

        //Assert

    }
    
}