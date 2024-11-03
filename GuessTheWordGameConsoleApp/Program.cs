using GuessTheWordGameConsoleApp;
using GuessTheWordGameConsoleApp.DisplaySettings;
using GuessWordGames.Models;

var isContinue = true;

void SetUpGamePool(ConsoleUserInterface userInterface,
	RandomProvider randomProvider,
	ConsoleGameMessagesDisplay consoleGameMessagesDisplay
	)
{
	while (isContinue)
	{
		GuessWordGameSession game = new(userInterface, randomProvider);
		game.LaunchGame();
		
		isContinue = consoleGameMessagesDisplay.AskIsContinue();
	}
}

ConsoleUserInterface consoleUserInterface = new();
ConsoleGameMessagesDisplay display = new();
RandomProvider randomProvider = new();


display.ShowGreetMessage();
SetUpGamePool(consoleUserInterface, randomProvider, display);
display.ShowExitMessage();
