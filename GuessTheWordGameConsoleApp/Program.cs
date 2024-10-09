using GuessWordGames;
void ChangeContinueStatus(string answere, out bool IsContinue)
{
    if (answere.ToLower().Contains("y"))
    {
        IsContinue = true;
    }
    else
    {
        IsContinue = false;
    }
}
const string seccessResult = "You have guessed the word!";

var guessWordGame = new GuessWordGame();
bool IsContinue = true;
string result = string.Empty;


while (IsContinue)
{
    string input = Console.ReadLine();

    result = guessWordGame.GetResultOfGuessGame(input);
    if(result != seccessResult)
    {
        Console.WriteLine(result);
        Console.WriteLine("do yo want to continue? y/n");
        string isContinueUserAnswer = Console.ReadLine() ?? "n";
        ChangeContinueStatus(isContinueUserAnswer, out IsContinue);
    }
    else
    {
        Console.WriteLine(seccessResult);
        break;
    }
}
