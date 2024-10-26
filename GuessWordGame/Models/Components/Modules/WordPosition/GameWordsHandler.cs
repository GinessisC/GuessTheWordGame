using GuessWordGames.Interfaces;

namespace GuessWordGames.Models.Components.Modules.WordPosition;

public class GameWordsHandler
{
	private const int _belowPos = -1;
	private const int _abovePos = 1;
	private const int _equal = 0;
	private IRandomProvider _randomProvider;
	public Word WordToGuess { get; }
	public WordsCollection WordsToGuess { get; }

	public GameWordsHandler(WordsCollection words, IRandomProvider randomProvider)
	{
		_randomProvider = randomProvider;
		WordsToGuess = words;

		int lastWordIndex = words.wordsList.Count - 1;
		int randomIndexOfWordList = randomProvider.Next(0, lastWordIndex);

		WordToGuess = words.wordsList[randomIndexOfWordList];
	}

	public bool IsGuessed(Word word)
	{
		return WordToGuess.Equals(word);
	}

	public WordPosition DefineWordPosition(Word word)
	{
		int comparison = WordToGuess.CompareTo(word);

		return comparison switch
		{
			_belowPos => WordPosition.Below,
			_abovePos => WordPosition.Above,
			_equal => WordPosition.Equal,
			_ => WordPosition.NotFound
		};
	}
}