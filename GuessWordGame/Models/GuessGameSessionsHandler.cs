using GuessWordGames.Interfaces;
using GuessWordGames.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models;

public class GuessGameSessionsHandler
{
    private bool _isContinue = true;
    private readonly IUserInterface _userInterface;
    private readonly IGameMessagesDisplayer _gameMessagesDisplayer;
    public GuessGameSessionsHandler(IUserInterface userInterface, IGameMessagesDisplayer gameMessagesDisplayer)
    {
        _gameMessagesDisplayer = gameMessagesDisplayer;
        _userInterface = userInterface; 
    }
    
    public void SetUpGamePool()
    {
        _gameMessagesDisplayer.ShowGreetMessage();
        while (_isContinue)
        {
            var game = CreateGame();
            game.LaunchGame();
            _isContinue = _gameMessagesDisplayer.AskIsContinue();
        }
        _gameMessagesDisplayer.ShowExitMessage();
    }
    private GuessWordGameSession CreateGame()
    {
        var game = new GuessWordGameSession(_userInterface);
        return game;
    }
}
