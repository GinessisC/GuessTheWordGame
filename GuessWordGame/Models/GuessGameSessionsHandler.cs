using GuessWordGames.Interfaces;

namespace GuessWordGames.Models;

public class GuessGameSessionsHandler
{
	private readonly IUserInterface _userInterface;
	private readonly IGameMessagesDisplay _gameMessagesDisplay;
	private readonly IRandomProvider _randomProvider;
	private bool _isContinue = true;

	public GuessGameSessionsHandler(IUserInterface userInterface,
		IGameMessagesDisplay gameMessagesDisplay,
		IRandomProvider randomProvider)
	{
		_randomProvider = randomProvider;
		_gameMessagesDisplay = gameMessagesDisplay;
		_userInterface = userInterface;
	}

	public void SetUpGamePool()
	{
		_gameMessagesDisplay.ShowGreetMessage();

		while (_isContinue)
		{
			GuessWordGameSession game = new GuessWordGameSession(_userInterface, _randomProvider);
			game.LaunchGame();
			_isContinue = _gameMessagesDisplay.AskIsContinue();
		}

		_gameMessagesDisplay.ShowExitMessage();
	}
}