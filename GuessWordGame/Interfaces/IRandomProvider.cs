using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Modules.RandomModules;

public interface IRandomProvider
{
    int Next(int minValue, int maxValue);
}
