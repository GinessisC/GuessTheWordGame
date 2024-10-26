namespace GuessWordGames.Models.Components;

public class WordsCollection : List<Word>
{
	public List<Word> wordsList = new();

	public WordsCollection()
	{
	}

	public WordsCollection(List<Word> words)
	{
		wordsList = words;
	}
}