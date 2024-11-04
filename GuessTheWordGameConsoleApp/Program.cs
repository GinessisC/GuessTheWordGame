using GuessTheWordGameConsoleApp;
using GuessTheWordGameConsoleApp.DisplaySettings;
using GuessWordGames.Models;

bool isContinue = true;

ConsoleUserInterface consoleUserInterface = new();
ConsoleGameMessagesDisplay display = new();
RandomProvider randomProvider = new();

display.ShowGreetMessage();

while (isContinue)
{
	GuessWordGameSession game = new(consoleUserInterface, randomProvider);
	game.LaunchGame();

	isContinue = display.AskIsContinue();
}

display.ShowExitMessage();