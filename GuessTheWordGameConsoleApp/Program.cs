using GuessTheWordGameConsoleApp;
using GuessTheWordGameConsoleApp.DisplaySettings;
using GuessWordGames.Models;

ConsoleUserInterface consoleUserInterface = new();
ConsoleGameMessagesDisplay display = new();
RandomProvider randomProvider = new();

GuessGameSessionsHandler games = new(consoleUserInterface, display, randomProvider);
games.SetUpGamePool();