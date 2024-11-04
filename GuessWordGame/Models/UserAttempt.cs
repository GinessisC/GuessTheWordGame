using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;

namespace GuessWordGames.Models;

public record UserAttempt
{
	public required Word InputWord { get; init; }
	public required bool IsSuccessful { get; init; }
	public required WordPosition WordPosition { get; init; }
}