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
    private readonly IStatisticConverter _statisticConverter;
    private UserGameStatistic _userGameStatistic;
    public GuessWordGame(IUserInterface userInterface,
         IStatisticConverter statisticConverter, 
         GameData gameData)
    {
        _gameData = gameData;
        _userInterface = userInterface;
        _statisticConverter = statisticConverter;
    }
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
        var wordsToGuess = new WordsToGuess(userInputData.GetWordsToGuess().ToList());
        var inputWord = string.Empty;

        DefineWords(wordsToGuess);
        DefineStatisticsData();

        while (_gameData.isContinue)
        {
            inputWord = _userInterface.GetUserWordAttempt();
            if (IsWordGuessed(inputWord))
            {
                _userGameStatistic.GuessedWord = inputWord;
                EndGame();
                break;
            }
            else
            {
                DoInCaseOfFailAttempt(inputWord);
                continue;
            }
        }
    }
    private void EndGame()
    {
        _userInterface.CongratulateOnSuccessfulAttempt();
        _gameData.isContinue = false;
        _statisticConverter.ShowConvertedStatistics(_userGameStatistic);
    }
    private void DoInCaseOfFailAttempt(string inputWord)
    {
        _userInterface.InformAboutWrongAnswer();
        _userGameStatistic.IncorrectGuessedWords.Add(inputWord);
        _userGameStatistic.FailedAttemptsCount++;
    }
    private void DefineWords(WordsToGuess words)
    {
        if (_gameData == null)
        {
            _gameData = new GameData(words);
        }
        
    }
    private void DefineStatisticsData()
    {
        _userGameStatistic = new(new WordsToGuess(new List<string>()));
        _userGameStatistic.IncorrectGuessedWords = new(new List<string>() { });
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