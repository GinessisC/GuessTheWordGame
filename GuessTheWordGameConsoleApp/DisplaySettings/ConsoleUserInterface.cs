using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;

namespace GuessTheWordGameConsoleApp.DisplaySettings;

internal class ConsoleUserInterface : IUserInterface
{
	private const string Separator = ", ";

	public void WhenWordIsAbove(Word userWord)
	{
		Console.WriteLine($"Right word is higher then {userWord}");
	}

	public void WhenWordIsBelow(Word userWord)
	{
		Console.WriteLine($"Right word is lower then {userWord}");
	}

	public void WhenWordIsNotFound(Word userWord)
	{
		Console.WriteLine($"Word {userWord} was not found");
	}

	public void WhenWordIsGuessed(Word userWord)
	{
		Console.WriteLine($"\nCongratulations!!! Right word was guessed! It was {userWord}\n");
	}

	public WordsCollection GetWordsToGuess()
	{
		List<Word> wordsToGuessList = GetUserWordsToGuess();

		return new WordsCollection(wordsToGuessList);
	}

	public Word GetUserWordAttempt()
	{
		Console.WriteLine("Enter word >>>");
		string wordValue = Console.ReadLine() ?? string.Empty;
		Word inputWord = new(wordValue);

		return inputWord;
	}

	private List<Word> GetUserWordsToGuess()
	{
		Console.WriteLine("Enter wordsList that you what to guess: ");
		string words = Console.ReadLine() ?? string.Empty;
		List<Word> wordsList = ConvertWordsToList(words);

		return wordsList;
	}

	private List<Word> ConvertWordsToList(string words)
	{
		string[] wordsArray = words.Split(Separator);
		List<Word> wordsList = new();

		foreach (string strWord in wordsArray)
		{
			Word word = new(strWord);
			wordsList.Add(word);
		}

		return wordsList.ToList();
	}
}