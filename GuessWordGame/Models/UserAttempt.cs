using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;

public class UserAttempt
{
	public Word InputWord { get; }
	public bool IsSuccessful { get; set; }
	public WordPosition WordPosition { get; }

	public UserAttempt(Word inputWord,
		WordPosition wordPosition)
	{
		WordPosition = wordPosition;
		InputWord = inputWord;
	}
}