using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components;

public class WordsCollection : List<Word>
{
    public List<Word> wordsList = new List<Word>();
    public WordsCollection()
    {
        
    }
    public WordsCollection(List<Word> words)
    {
        this.wordsList = words;  
    }
}
