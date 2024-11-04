using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;

public class GuessWordGameSession
{
	private readonly IUserInterface _userInterface;
	private readonly GameWordsHandler _gameWordsToGuess;
	private readonly List<UserAttempt> _userAttempts = new();
	private bool _isFinished;
	public IEnumerable<UserAttempt> Attempts => _userAttempts;

	public GuessWordGameSession(IUserInterface userInterface, IRandomProvider randomProvider)
	{
		WordsCollection words = userInterface.GetWordsToGuess();
		_gameWordsToGuess = new GameWordsHandler(words, randomProvider);
		_userInterface = userInterface;
	}

	public void LaunchGame()
	{
		while (_isFinished is false)
			_isFinished = TryGuess();
	}

	private bool TryGuess()
	{
		Word userWordInput = _userInterface.GetUserWordAttempt();
		WordPosition wordPosition = _gameWordsToGuess.DefineWordPosition(userWordInput);

		bool isWordGuessed = IsEqual(wordPosition, userWordInput);

		UserAttempt userAttempt = new()
		{
			WordPosition = wordPosition,
			InputWord = userWordInput,
			IsSuccessful = isWordGuessed
		};

		_userAttempts.Add(userAttempt);

		return isWordGuessed;
	}

	private bool IsEqual(WordPosition userWordPosition, Word inputWord)
	{
		return userWordPosition switch
		{
			WordPosition.Above => MakeOnAbove(inputWord),
			WordPosition.Below => MakeOnBelow(inputWord),
			WordPosition.Equal => MakeOnEqual(inputWord),
			WordPosition.NotFound => MakeOnNotFound(inputWord),
			_ => throw new ArgumentOutOfRangeException(nameof(userWordPosition), userWordPosition, null)
		};
	}

	private bool MakeOnNotFound(Word inputWord)
	{
		_userInterface.WhenWordIsNotFound(inputWord);

		return false;
	}

	private bool MakeOnBelow(Word inputWord)
	{
		_userInterface.WhenWordIsBelow(inputWord);

		return false;
	}

	private bool MakeOnAbove(Word inputWord)
	{
		_userInterface.WhenWordIsAbove(inputWord);

		return false;
	}

	private bool MakeOnEqual(Word inputWord)
	{
		_userInterface.WhenWordIsGuessed(inputWord);

		return true;
	}
}