using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWordGameConsoleApp;

class ConsoleStatisticConverter : IStatisticConverter
{
    public void ShowConvertedStatistics(IUserStatistic userStatistic)
    {
        StringBuilder incorrectGuessedWordsStr = new StringBuilder();
        var incorrectGuessedWords = userStatistic.IncorrectGuessedWords;

        foreach (var incorrectGuessedWord in incorrectGuessedWords)
        {
            incorrectGuessedWordsStr.Append($"{incorrectGuessedWord}, ");
        }
        var statisticToDisplay = $"""
            -------------------!GAME FINISHED!------------------------
            Your statistic: 
             failed attempts: {userStatistic.FailedAttemptsCount}
             guessed word: {userStatistic.GuessedWord}
             incorrectGuessedWordsStr: {incorrectGuessedWordsStr.ToString() ?? "0"}
            ---------------------------------------------------------- 
            """;
        Console.WriteLine(statisticToDisplay);
    }
}
