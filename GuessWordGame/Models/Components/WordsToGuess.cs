using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessWordGames.Models.Components;

public class WordsToGuess : IList<string>
{
    private List<string> _words = new List<string>();
    public string this[int index]
    {
        get => _words[index];
        set => _words[index] = value;
    }
    public WordsToGuess()
    {
        
    }
    public WordsToGuess(List<string> words)
    {
        _words = words;
    }

    public int Count => _words.Count;

    public bool IsReadOnly => false;

    public void Add(string item)
    {
        _words.Add(item);
    }

    public void Clear()
    {
        _words.Clear();
    }

    public bool Contains(string item)
    {
        return _words.Contains(item);
    }

    public void CopyTo(string[] array, int arrayIndex)
    {
        _words.CopyTo(array, arrayIndex);
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _words.GetEnumerator();
    }

    public int IndexOf(string item)
    {
        return _words.IndexOf(item);
    }

    public void Insert(int index, string item)
    {
        _words.Insert(index, item);
    }

    public bool Remove(string item)
    {
        return _words.Remove(item);
    }

    public void RemoveAt(int index)
    {
        _words.RemoveAt(index);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
