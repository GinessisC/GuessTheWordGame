using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.RandomModules;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;
public class GuessWordGameSession
{
    private bool _isFinished = false;
    private GameWordsHandler _gameWordsToGuess;
    private readonly IUserInterface _userInterface;
    List<UserAttempt> userAttempts = new() { };

    public GuessWordGameSession(IUserInterface userInterface)
    {
        RandomProvider randomProvider = new();

        var words = userInterface.GetWordsToGuess();
        _gameWordsToGuess = new(words, randomProvider);
        _userInterface = userInterface;
    }
    public void LaunchGame()
    {
        GameProcess();
    }
    
    private void GameProcess()
    {
        var inputWord = string.Empty;

        while (_isFinished is false)
        {
            var IsGuessed = TryGuess();
        }
    }
    private bool TryGuess()
    {
        var userInputData = _gameWordsToGuess.WordsToGuess;
        var userWords = _gameWordsToGuess.WordsToGuess;
        var userWordInput = _userInterface.GetUserWordAttempt();
        var wordPosition = _gameWordsToGuess.DefineWordPosition(userWordInput);

        var userAttempt = new UserAttempt(userWordInput, false, wordPosition);
        DefineAction(wordPosition, userWordInput);
        if (_gameWordsToGuess.IsGuessed(userWordInput))
        {
            userAttempt.IsSuccessful = true;
        }
        userAttempts.Add(userAttempt);
        return _isFinished;
    }
    private void DefineAction(WordPosition userWordPosition, Word inputWord)
    {
        switch (userWordPosition)
        {
            case WordPosition.NotFound:
                MakeOnNotFound(inputWord);
                break;
            case WordPosition.Above:
                MakeOnAbove(inputWord);
                break;
            case WordPosition.Below:
                MakeOnBelow(inputWord);
                break;
            case WordPosition.Equal:
                MakeOnEqual(inputWord);
                break;
            default:
                throw new NotImplementedException();
        };
    }

    private void MakeOnNotFound(Word inputWord)
    {
        UserAttempt userAttempt = new(inputWord, isGuessed: false, WordPosition.NotFound);
        userAttempts.Add(userAttempt);
        _userInterface.WhenWordIsNotFound(inputWord);
    }
    private void MakeOnBelow(Word inputWord)
    {
        UserAttempt userAttempt = new(inputWord, isGuessed: false, WordPosition.Below);
        userAttempts.Add(userAttempt);
        _userInterface.WhenWordIsBelow(inputWord);
    }
    private void MakeOnAbove(Word inputWord)
    {
        UserAttempt userAttempt = new(inputWord, isGuessed: false, WordPosition.Above);
        userAttempts.Add(userAttempt);
        _userInterface.WhenWordIsAbove(inputWord);
    }
    private void MakeOnEqual(Word inputWord)
    {
        _isFinished = true;
        UserAttempt userAttempt = new(inputWord, isGuessed: true, WordPosition.Equal);
        userAttempts.Add(userAttempt);
        _userInterface.WhenWordIsGuessed(inputWord);
    }
}