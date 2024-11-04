namespace GuessWordGames.Models.Components;

public class WordsCollection : List<Word>
{
	public WordsCollection(IEnumerable<Word> words) : base(words)
	{
	}
}