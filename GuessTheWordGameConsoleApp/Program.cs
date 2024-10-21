using GuessTheWordGameConsoleApp;
using GuessTheWordGameConsoleApp.DisplaySettings;
using GuessWordGames;
using GuessWordGames.Models;

var consoleUserInterface = new ConsoleUserInterface();
ConsoleGameMessagesDisplayer displayer = new();

GuessGameSessionsHandler games = new(consoleUserInterface, displayer);
games.SetUpGamePool();
