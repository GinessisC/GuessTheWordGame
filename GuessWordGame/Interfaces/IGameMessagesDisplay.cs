namespace GuessWordGames.Interfaces;

public interface IGameMessagesDisplay
{
	void ShowGreetMessage();
	void ShowExitMessage();
	bool AskIsContinue();
}