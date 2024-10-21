using GuessWordGames.Models.Components;

namespace GuessWordGames.Interfaces;
public interface IUserInterface
{
    void WhenWordIsAbove(Word userWord);
    void WhenWordIsBelow(Word userWord);
    void WhenWordIsNotFound(Word userWord);
    void WhenWordIsGuessed(Word userWord);
    Word GetUserWordAttempt();
    WordsCollection GetWordsToGuess();
}
