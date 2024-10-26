using GuessWordGames.Models.Components;

namespace GuessWordGames.Interfaces;

public interface IWordPositionDisplayer
{
	void WordIsAbove(Word userWord);
	void WordIsBelow(Word userWord);
	void WordIsNotFound(Word userWord);
	void WordIsGuessed(Word userWord);
}