using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;

namespace GuessTheWordGameConsoleApp.DisplaySettings;

internal class ConsoleUserInterface : IUserInterface
{
	private readonly string _separator = ", ";

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
		Console.WriteLine($"\nCongritulations!!! Right word was guessed! It was {userWord}\n");
	}

	public WordsCollection GetWordsToGuess()
	{
		List<Word> wordsToGuessList = GetUserWordsToGuess();

		return new WordsCollection(wordsToGuessList);
	}

	public Word GetUserWordAttempt()
	{
		Console.WriteLine("Enter word >>>");
		string wordValue = Console.ReadLine();
		Word inputWord = new(wordValue);

		return inputWord;
	}

	public void Greet()
	{
		Console.WriteLine("""
						   Hi! Welcome to the guess word game! 
						   Enter words separated by coma (, ) and program choose one random word
						""");
	}

	public List<Word> GetUserWordsToGuess()
	{
		Console.WriteLine("Enter wordsList that you what to guess: ");
		string words = Console.ReadLine();
		List<Word> wordsList = ConvertWordsToList(words);

		return wordsList;
	}

	private List<Word> ConvertWordsToList(string words)
	{
		string[] wordsArray = words.Split(_separator);
		List<Word> wordsList = new();

		foreach (string strWord in wordsArray)
		{
			Word word = new(strWord);
			wordsList.Add(word);
		}

		return wordsList.ToList();
	}
}