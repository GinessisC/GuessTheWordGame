using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Modules.RandomModules;

class RandomProvider : IRandomProvider
{
    public int Next(int minValue, int maxValue)
    {
        return Random.Shared.Next(minValue, maxValue);
    }
}
