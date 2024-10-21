using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Interfaces
{
    public interface IGameMessagesDisplayer
    {
        void ShowGreetMessage();
        void ShowExitMessage();
        bool AskIsContinue();
    }
}
