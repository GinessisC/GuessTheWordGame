using GuessWordGames.Interfaces;

namespace GuessWordGames.Models.Components.Modules.WordPosition;

public class GameWordsHandler
{
	public Word WordToGuess { get; }
	public WordsCollection WordsToGuess { get; }

	public GameWordsHandler(WordsCollection words, IRandomProvider randomProvider)
	{
		WordsToGuess = words;

		int lastWordIndex = words.Count - 1;
		int randomIndexOfWordList = randomProvider.Next(0, lastWordIndex);

		WordToGuess = words[randomIndexOfWordList];
	}

	public bool IsGuessed(Word word)
	{
		return WordToGuess.Equals(word);
	}

	public WordPosition DefineWordPosition(Word word)
	{
		int comparison = WordToGuess.CompareTo(word);

		return (WordPosition) comparison;
	}
}