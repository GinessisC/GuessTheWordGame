using GuessTheWordGameConsoleApp;
using GuessWordGames;
using GuessWordGames.Models;

var consoleStatisticConverter = new ConsoleStatisticConverter();
var consoleUserInterface = new ConsoleUserInterface();
GuessWordGame guessWordGame = new(consoleUserInterface, consoleStatisticConverter);

guessWordGame.LaunchGame();