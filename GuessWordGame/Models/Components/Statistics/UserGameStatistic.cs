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
        public WordsToGuess incorrectGuessedWords { get; set; }
        public int failedAttemptsCount { get; set; } = 0;
        public string guessedWord { get; set; } = string.Empty;

        public UserGameStatistic(WordsToGuess incorrectGuessedWords,
            int failedAttemptsCount,
            string guessedWord)
        {
            this.incorrectGuessedWords = incorrectGuessedWords;
            this.failedAttemptsCount = failedAttemptsCount;
            this.guessedWord = guessedWord;
        }
        public UserGameStatistic(WordsToGuess incorrectGuessedWords)
        {
            this.incorrectGuessedWords = incorrectGuessedWords;
        }

    }
}
