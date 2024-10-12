using System.Xml.Serialization;
using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Statistics;
using GuessWordGames.Models.Components.Statistics.Interfaces;

namespace GuessWordGames.Models;

public class GuessWordGame
{
    private string _wordToGuess;
    private IUserInterface _userInterface;
    private WordsToGuess _wordsToGuess = new() { };
    //private IUserStatisticCounter _userStatisticCounter;
    private IStatisticConverter _statisticConverter;
    //private IUserStatistic _userStatistic;
    private bool isContinue = true;
    private UserGameStatistic _userGameStatistic;

    public GuessWordGame(List<string> wordstoGuess,
        IUserInterface userInterface, IStatisticConverter statisticConverter)
    {
        _userInterface = userInterface;
        _wordsToGuess = new(wordstoGuess);
        _statisticConverter = statisticConverter;

        int lastIndexOfWordsList = _wordsToGuess.Count - 1;
        int randomIndexOfWordList = Random.Shared.Next(0, lastIndexOfWordsList);

        _wordToGuess = _wordsToGuess[randomIndexOfWordList];
    }

    public GuessWordGame(IUserInterface userInterface)
    {
        _userInterface = userInterface;

        int lastIndexOfWordsList = _wordsToGuess.Count - 1;
        int randomIndexOfWordList = Random.Shared.Next(0, lastIndexOfWordsList);

        _wordToGuess = _wordsToGuess[randomIndexOfWordList];
    }
    public void LaunchGame()
    {
        StartGame();
        GameProcess();
    }
    private void GameProcess()
    {
        _userGameStatistic = new(new WordsToGuess(new List<string>()));
        var inputWord = string.Empty;

        _userGameStatistic.incorrectGuessedWords = new(new List<string>() { });

        while (isContinue)
        {
            _userInterface.AskMove();
            inputWord = _userInterface.inputWord;

            if (IsWordGuessed(inputWord))
            {
                _userGameStatistic.guessedWord = inputWord;
                
                _userInterface.CongratulateOnSuccessfulAttempt();
                isContinue = false;
                _statisticConverter.ShowConvertedStatistics(_userGameStatistic);
                
                break;
            }
            else
            {
                _userInterface.InformAboutWrongAnswere();
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
        return _wordToGuess == inputWord;
    }
}