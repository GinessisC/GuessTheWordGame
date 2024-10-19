using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Interfaces;

public interface IUserInterface
{
    void Greet();
    string GetUserWordAttempt();
    void CongratulateOnSuccessfulAttempt();
    void InformAboutWrongAnswer();
    IInputUserData GetInputData();
}
