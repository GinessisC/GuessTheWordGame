using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components.Statistics
{
    class UserGameStatistic : IUserStatistic
    {
        public WordsToGuess IncorrectGuessedWords { get; set; }
        public int FailedAttemptsCount { get; set; } = 0;
        public string GuessedWord { get; set; } = string.Empty;

        public UserGameStatistic(WordsToGuess incorrectGuessedWords,
            int failedAttemptsCount,
            string guessedWord)
        {
            this.IncorrectGuessedWords = incorrectGuessedWords;
            this.FailedAttemptsCount = failedAttemptsCount;
            this.GuessedWord = guessedWord;
        }
        public UserGameStatistic(WordsToGuess incorrectGuessedWords)
        {
            this.IncorrectGuessedWords = incorrectGuessedWords;
        }

    }
}
