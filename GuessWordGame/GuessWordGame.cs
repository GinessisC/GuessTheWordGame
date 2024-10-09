using System.Xml.Serialization;

namespace GuessWordGames;

public class GuessWordGame
{
    public GuessWordGame(string wordToGuess)
    {
        _wordToGuess = wordToGuess;
    }

    public GuessWordGame() //for tests
    {
        SetRandomWord();
    }

    public string GetResultOfGuessGame(string inputWord)
    {
        return IsWordGuessed(inputWord) ? "You have guessed the word!" :  $"{inputWord} is incorrect! Try again!";
    }
    private void SetRandomWord()
    {
        int lastIndexOfWordsList = words.Count - 1;
        int randomIndexOfWordList = Random.Shared.Next(0, lastIndexOfWordsList);

        _wordToGuess = words[randomIndexOfWordList];
    }
    public bool IsWordGuessed(string inputWord)
    {
        return _wordToGuess == inputWord;
    }

    private string _wordToGuess;

    private List<string> words = new List<string>()
    {
        "test", "words", "random"
    };
}
