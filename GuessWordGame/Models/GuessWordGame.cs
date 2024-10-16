using System.Xml.Serialization;
using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Statistics;
using GuessWordGames.Models.Components.Statistics.Interfaces;

namespace GuessWordGames.Models;
public class GuessWordGame
{
    private GameData _gameData;
    private readonly IUserInterface _userInterface;
    private IStatisticConverter _statisticConverter;
    private UserGameStatistic _userGameStatistic;

    public GuessWordGame(IUserInterface userInterface,
         IStatisticConverter statisticConverter)
    {
        _userInterface = userInterface;
        _statisticConverter = statisticConverter;
    }

    public void LaunchGame()
    {
        StartGame();
        GameProcess();
    }
    
    private void GameProcess()
    {
        var userInputData = _userInterface.GetInputData();

        var wordsToGuess = new WordsToGuess(userInputData.GetGeneralWords().ToList());
        
        var inputWord = string.Empty;

        _gameData = new GameData(wordsToGuess);
        _userGameStatistic = new(new WordsToGuess(new List<string>()));
        _userGameStatistic.incorrectGuessedWords = new(new List<string>() { });

        while (_gameData.isContinue)
        {
            inputWord = _userInterface.UserMove();
            if (IsWordGuessed(inputWord))
            {
                _userGameStatistic.guessedWord = inputWord;
                
                _userInterface.CongratulateOnSuccessfulAttempt();
                _gameData.isContinue = false;
                _statisticConverter.ShowConvertedStatistics(_userGameStatistic);
                
                break;
            }
            else
            {
                _userInterface.InformAboutWrongAnswer();
                _userGameStatistic.incorrectGuessedWords.Add(inputWord);
                _userGameStatistic.failedAttemptsCount++;
                continue;
            }
        }
    }
    
    private void StartGame()
    {
        _userInterface.Greet();
    }

    private bool IsWordGuessed(string inputWord)
    {
        return _gameData.wordToGuess == inputWord;
    }
}