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
        var incorrectGuessedWords = userStatistic.incorrectGuessedWords;

        foreach (var incorrectGuessedWord in incorrectGuessedWords)
        {
            incorrectGuessedWordsStr.Append($"{incorrectGuessedWord}, ");
        }
        Console.WriteLine($"\n-------------------!GAME FINISHED!------------------------\nYour statistic: \n\n" +
            $" failed attempts: {userStatistic.failedAttemptsCount}\n" +
            $" guessed word: {userStatistic.guessedWord}\n" +
            $" incorrectGuessedWordsStr: {incorrectGuessedWordsStr.ToString() ?? "0"}\n" +
            $"----------------------------------------------------------");
    }
}
