using GuessWordGames.Models.Components;
using GuessWordGames.Models.Components.Modules.WordPosition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models;

class UserAttempt
{
    public Word InputWord { get; }
    public bool IsSuccessful { get; set; }
    public WordPosition WordPosition { get; }
    public UserAttempt(Word inputWord, bool isGuessed, WordPosition wordPosition)
    {
        WordPosition = wordPosition;
        InputWord = inputWord;
        IsSuccessful = isGuessed;
    }
}
