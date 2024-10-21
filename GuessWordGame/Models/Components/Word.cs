using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components;

public class Word : IComparable<Word>
{
    private string _value;
    public Word(string value)
    {
        _value = value.Trim();
    }
    public int CompareTo(Word? other)
    {
        return string.Compare(_value, other._value, StringComparison.CurrentCultureIgnoreCase);
    }
    public override string ToString()
    {
        return _value;
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Word word)
        {
            return false;
        }
        return string.Equals(_value, word._value, StringComparison.CurrentCultureIgnoreCase);
    }
}
