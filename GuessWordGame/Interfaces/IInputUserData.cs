using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Interfaces
{
    public interface IInputUserData
    {
        //string WordToGuess { get; set; }
        IList<string> GetGeneralWords();
    }
}
