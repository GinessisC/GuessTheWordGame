using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Statistics.Interfaces
{
    public interface IUserStatistic
    {
        WordsToGuess incorrectGuessedWords { get; set; }
        int failedAttemptsCount { get; set; }
        string guessedWord { get; set; }
    }
}
