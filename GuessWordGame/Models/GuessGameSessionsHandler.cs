using GuessWordGames.Interfaces;

namespace GuessWordGames.Models;

public class GuessGameSessionsHandler(
	IUserInterface userInterface,
	IGameMessagesDisplay gameMessagesDisplay,
	IRandomProvider randomProvider)
{
	private bool _isContinue = true;

	public void SetUpGamePool()
	{
		gameMessagesDisplay.ShowGreetMessage();

		while (_isContinue)
		{
			GuessWordGameSession game = new(userInterface, randomProvider);
			game.LaunchGame();
			_isContinue = gameMessagesDisplay.AskIsContinue();
		}

		gameMessagesDisplay.ShowExitMessage();
	}
}