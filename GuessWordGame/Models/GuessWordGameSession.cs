using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;

public class GuessWordGameSession
{
	private readonly IUserInterface _userInterface;
	private readonly GameWordsHandler _gameWordsToGuess;
	private readonly List<UserAttempt> _userAttempts = new();
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
			bool isGuessed = TryGuess();
		}
	}

	private bool TryGuess()
	{
		Word userWordInput = _userInterface.GetUserWordAttempt();
		WordPosition wordPosition = _gameWordsToGuess.DefineWordPosition(userWordInput);

		UserAttempt userAttempt = new(userWordInput, wordPosition)
		{
			IsSuccessful = false
		};
		
		DefineAction(wordPosition, userWordInput);

		if (_gameWordsToGuess.IsGuessed(userWordInput))
		{
			userAttempt.IsSuccessful = true;
		}

		_userAttempts.Add(userAttempt);

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
	}

	private void MakeOnNotFound(Word inputWord)
	{
		_userInterface.WhenWordIsNotFound(inputWord);
	}

	private void MakeOnBelow(Word inputWord)
	{
		_userInterface.WhenWordIsBelow(inputWord);
	}

	private void MakeOnAbove(Word inputWord)
	{
		_userInterface.WhenWordIsAbove(inputWord);
	}

	private void MakeOnEqual(Word inputWord)
	{
		_isFinished = true;
		_userInterface.WhenWordIsGuessed(inputWord);
	}
}