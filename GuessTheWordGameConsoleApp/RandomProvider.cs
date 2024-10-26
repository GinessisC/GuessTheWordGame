using GuessWordGames.Interfaces;

namespace GuessTheWordGameConsoleApp;

internal class RandomProvider : IRandomProvider
{
	public int Next(int minValue, int maxValue)
	{
		return Random.Shared.Next(minValue, maxValue);
	}
}