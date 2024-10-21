using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;

namespace GuessTheWordGameConsoleApp.DisplaySettings;
class ConsoleUserInterface : IUserInterface
{
    private string _separator = ", ";
    private List<Word> ConvertWordsToList(string words)
    {
        var wordsArray = words.Split(_separator);
        List<Word> wordsList = new List<Word>() { };
        foreach (var strWord in wordsArray)
        {
            Word word = new(strWord);
            wordsList.Add(word);
        }
        return wordsList.ToList();
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
        var wordsList = ConvertWordsToList(words);
        return wordsList;
    }

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
        var wordsToGuessList = GetUserWordsToGuess();
        return new WordsCollection(wordsToGuessList);
    }
    public Word GetUserWordAttempt()
    {
        Console.WriteLine("Enter word >>>");
        string wordValue = Console.ReadLine();
        Word inputWord = new(wordValue);
        return inputWord;
    }
}
