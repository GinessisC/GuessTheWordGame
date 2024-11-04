using GuessWordGames.Interfaces;

namespace GuessTheWordGameConsoleApp.DisplaySettings;

internal class ConsoleGameMessagesDisplay : IGameMessagesDisplay
{
	private static readonly string _separator = ", ";
	public bool AskIsContinue()
	{
		Console.WriteLine("Continue? y/n\n");
		string isContinueStr = Console.ReadLine() ?? string.Empty;
		Console.Clear();

		return IsContinue(isContinueStr);
	}

	public void ShowExitMessage()
	{
		Console.WriteLine("""
						Thanks for playing, exiting...
						""");
	}

	public void ShowGreetMessage()
	{
		Console.WriteLine($"""
							   Hi! Welcome to the guess word game! 
							   Enter words separated by coma ({_separator}) and program choose one random word

							""");
	}

	private bool IsContinue(string? userAnswer)
	{
		return userAnswer != null && userAnswer.Contains('y')
			? true
			: false;
	}
}