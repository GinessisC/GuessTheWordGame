using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Statistics.Interfaces
{
    interface IUserStatisticCounter
    {
        IUserStatistic CountStatistic();
    }
}
