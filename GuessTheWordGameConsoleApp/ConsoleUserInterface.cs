using GuessWordGames.Interfaces;

namespace GuessTheWordGameConsoleApp;
class ConsoleUserInterface : IUserInterface
{
    private List<string> ConvertWordsToList(string words)
    {
        var wordsArray = words.Split(", ");
        return wordsArray.ToList();
    }
    public string inputWord {  get; set; }

    public string GetUserWordAttempt()
    {
        Console.WriteLine("Guess the word >>> ");
        inputWord = Console.ReadLine();
        return inputWord;
    }

    public void CongratulateOnSuccessfulAttempt()
    {
        Console.WriteLine("Congratulations! You guessed the word!");
    }

    public void Greet()
    {
        Console.WriteLine("""
            Hi! Welcome to the guess word game! 
            Enter words separated by coma (,) and program choose one random word
         """);
    }

    public void InformAboutWrongAnswer()
    {
        Console.WriteLine("Incorrect! Try again!");
    }

    public List<string> GetUserWordsToGuess()
    {
        Console.WriteLine("Enter wordsList that you what to guess: ");
        string words = Console.ReadLine();
        var wordsList = ConvertWordsToList(words);
        return wordsList;

    }

    public IInputUserData GetInputData()
    {
        string wordsToGuess = Console.ReadLine();
        var wordsToGuessList = ConvertWordsToList(wordsToGuess);
        var data = new ConsoleInputData(wordsToGuessList);

        return data;
    }
}
