using GuessWordGames.Interfaces;

namespace GuessWordGames.Models;

public class GuessGameSessionsHandler
{
	public readonly List<GuessWordGameSession> SavedGuessGameSessions = new();
	private readonly IUserInterface _userInterface;
	private readonly IGameMessagesDisplay _gameMessagesDisplay;
	private readonly IRandomProvider _randomProvider;
	private bool _isContinue = true;

	public GuessGameSessionsHandler(IUserInterface userInterface,
		IGameMessagesDisplay gameMessagesDisplay,
		IRandomProvider randomProvider)
	{
		_userInterface = userInterface;
		_gameMessagesDisplay = gameMessagesDisplay;
		_randomProvider = randomProvider;
	}

	public void AppendSession(GuessWordGameSession guessGameSession)
	{
		SavedGuessGameSessions.Append(guessGameSession);
	}
	
	// public void SetUpGamePool()
	// {
	// 	while (_isContinue)
	// 	{
	// 		GuessWordGameSession game = new(_userInterface, _randomProvider);
	// 		game.LaunchGame();
	// 		
	// 		AppendSession(game);
	// 		_isContinue = _gameMessagesDisplay.AskIsContinue();
	// 	}
	// }
}