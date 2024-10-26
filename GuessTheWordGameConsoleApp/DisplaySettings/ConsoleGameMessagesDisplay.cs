using GuessWordGames.Interfaces;

namespace GuessTheWordGameConsoleApp.DisplaySettings;

internal class ConsoleGameMessagesDisplay : IGameMessagesDisplay
{
	private static readonly string _separator = ", ";

	private static readonly string _greetMessage = $"""
													   Hi! Welcome to the guess word game! 
													   Enter words separated by coma ({_separator}) and program choose one random word

													""";

	private static readonly string _exitMessage = """
												Thanks for playing, exiting...
												""";

	private static readonly string _askContinueMessage = "Continue? y/n\n";

	public bool AskIsContinue()
	{
		Console.WriteLine(_askContinueMessage);
		string isContinueStr = Console.ReadLine();
		Console.Clear();

		return IsContinue(isContinueStr);
	}

	public void ShowExitMessage()
	{
		Console.WriteLine(_exitMessage);
	}

	public void ShowGreetMessage()
	{
		Console.WriteLine(_greetMessage);
	}

	private bool IsContinue(string userAnswere)
	{
		return userAnswere.Contains('y')
			? true
			: false;
	}
}