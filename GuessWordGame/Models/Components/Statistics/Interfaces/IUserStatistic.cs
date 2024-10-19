using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Statistics.Interfaces
{
    public interface IUserStatistic
    {
        WordsToGuess IncorrectGuessedWords { get; set; }
        int FailedAttemptsCount { get; set; }
        string GuessedWord { get; set; }
    }
}
