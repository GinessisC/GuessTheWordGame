using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components
{
    public class GameData
    {
        public bool isContinue = true;
        public string wordToGuess = string.Empty;
        public GameData(WordsToGuess words)
        {
            int lastIndexOfWordsList = words.wordsList.Count - 1;
            int randomIndexOfWordList = Random.Shared.Next(0, lastIndexOfWordsList);

            wordToGuess = words.wordsList[randomIndexOfWordList];
        }
    }
}
