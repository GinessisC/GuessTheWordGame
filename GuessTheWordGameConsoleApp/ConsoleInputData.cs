using GuessWordGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWordGameConsoleApp
{
    class ConsoleInputData : IInputUserData
    {
        private List<string> _words = new() { };
        public ConsoleInputData(List<string> words)
        {
            _words = words;
        }
        public IList<string> GetWordsToGuess()
        {
            return _words;
        }
    }
}
