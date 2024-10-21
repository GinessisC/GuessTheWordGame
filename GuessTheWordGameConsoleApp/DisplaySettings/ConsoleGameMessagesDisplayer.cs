using GuessWordGames.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheWordGameConsoleApp.DisplaySettings;

class ConsoleGameMessagesDisplayer : IGameMessagesDisplayer
{
    private static string _separator = ", ";
    private static string _greetMessage = $"""
        Hi! Welcome to the guess word game! 
        Enter words separated by coma ({_separator}) and program choose one random word

     """;
    private static string _exitMessage = """
        Thanks for playing, exiting...
        """;
    private static string _askContinueMessage = "Continue? y/n\n";
    public bool AskIsContinue()
    {
        
        Console.WriteLine(_askContinueMessage);
        string isContinueStr = Console.ReadLine();
        Console.Clear();
        return IsContinue(isContinueStr);
    }
    private bool IsContinue(string userAnswere)
    {
        return userAnswere.Contains('y') ? true
            : false;
    }
    public void ShowExitMessage()
    {
        Console.WriteLine(_exitMessage);
    }

    public void ShowGreetMessage()
    {
        Console.WriteLine(_greetMessage);
    }
}
