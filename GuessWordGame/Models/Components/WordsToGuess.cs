using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components;

public class WordsToGuess : List<string>
{
    public List<string> wordsList = new List<string>();
    public WordsToGuess()
    {
        
    }
    public WordsToGuess(List<string> words)
    {
        this.wordsList = words;
    }
}
