using GuessTheWordGameConsoleApp;
using GuessWordGames;
using GuessWordGames.Models;

var consoleUserInterface = new ConsoleUserInterface();
GuessWordGame guessWordGame = new(consoleUserInterface, new ConsoleStatisticConverter());

guessWordGame.LaunchGame();
