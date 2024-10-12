﻿using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Interfaces
{
    public interface IStatisticConverter
    {
        void ShowConvertedStatistics(IUserStatistic userStatistic);
    }
}