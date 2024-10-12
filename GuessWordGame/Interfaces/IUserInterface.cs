using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Interfaces
{
    public interface IUserInterface
    {
        string inputWord { get; set; }
        void Greet();
        void AskMove();
        void CongratulateOnSuccessfulAttempt();
        void InformAboutWrongAnswere();
    }
}
