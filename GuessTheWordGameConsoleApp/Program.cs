using GuessTheWordGameConsoleApp;
using GuessWordGames;
using GuessWordGames.Models;

var consoleUserInterface = new ConsoleUserInterface();
GuessWordGame guessWordGame = new(new List<string> {"lol"}, consoleUserInterface, new ConsoleStatisticConverter());

guessWordGame.LaunchGame();
