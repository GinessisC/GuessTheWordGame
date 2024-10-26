using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;

public class GuessWordGameSession
{
	private readonly IUserInterface _userInterface;
	private readonly GameWordsHandler _gameWordsToGuess;
	private readonly List<UserAttempt> userAttempts = new();
	private IRandomProvider _randomProvider;
	private bool _isFinished;

	public GuessWordGameSession(IUserInterface userInterface, IRandomProvider randomProvider)
	{
		_randomProvider = randomProvider;

		WordsCollection words = userInterface.GetWordsToGuess();
		_gameWordsToGuess = new GameWordsHandler(words, randomProvider);
		_userInterface = userInterface;
	}

	public void LaunchGame()
	{
		GameProcess();
	}

	private void GameProcess()
	{
		string inputWord = string.Empty;

		while (_isFinished is false)
		{
			bool IsGuessed = TryGuess();
		}
	}

	private bool TryGuess()
	{
		WordsCollection userInputData = _gameWordsToGuess.WordsToGuess;
		WordsCollection userWords = _gameWordsToGuess.WordsToGuess;
		Word userWordInput = _userInterface.GetUserWordAttempt();
		WordPosition wordPosition = _gameWordsToGuess.DefineWordPosition(userWordInput);

		UserAttempt userAttempt = new(userWordInput, false, wordPosition);
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
		}

		;
	}

	private void MakeOnNotFound(Word inputWord)
	{
		UserAttempt userAttempt = new(inputWord, false, WordPosition.NotFound);
		userAttempts.Add(userAttempt);
		_userInterface.WhenWordIsNotFound(inputWord);
	}

	private void MakeOnBelow(Word inputWord)
	{
		UserAttempt userAttempt = new(inputWord, false, WordPosition.Below);
		userAttempts.Add(userAttempt);
		_userInterface.WhenWordIsBelow(inputWord);
	}

	private void MakeOnAbove(Word inputWord)
	{
		UserAttempt userAttempt = new(inputWord, false, WordPosition.Above);
		userAttempts.Add(userAttempt);
		_userInterface.WhenWordIsAbove(inputWord);
	}

	private void MakeOnEqual(Word inputWord)
	{
		_isFinished = true;
		UserAttempt userAttempt = new(inputWord, true, WordPosition.Equal);
		userAttempts.Add(userAttempt);
		_userInterface.WhenWordIsGuessed(inputWord);
	}
}