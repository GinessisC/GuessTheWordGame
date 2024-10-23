using GuessTheWordGameConsoleApp;
using GuessTheWordGameConsoleApp.DisplaySettings;
using GuessWordGames;
using GuessWordGames.Models;

var consoleUserInterface = new ConsoleUserInterface();
ConsoleGameMessagesDisplayer displayer = new();
RandomProvider randomProvider = new();

GuessGameSessionsHandler games = new(consoleUserInterface, displayer, randomProvider);
games.SetUpGamePool();
