using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components.Statistics.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWordGameConsoleApp;

class ConsoleUserInterface : IUserInterface
{
    public string inputWord {  get; set; }

    public void AskMove()
    {
        Console.WriteLine("Guess the word >>> ");
        inputWord = Console.ReadLine();
    }

    public void CongratulateOnSuccessfulAttempt()
    {
        Console.WriteLine("Congratulations! You guessed the word!");
    }

    public void Greet()
    {
        Console.WriteLine("Hi! Welcome to the guess word game! ");
    }

    public void InformAboutWrongAnswere()
    {
        Console.WriteLine("Incorrect! Try again!");
    }
}
