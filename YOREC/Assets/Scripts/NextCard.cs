using UnityEngine;

public class NextCard : MonoBehaviour
{
    public int NumberCard;
    [SerializeField] private ShufflingDeck _shufflingDeck;
    [SerializeField] private OpeningCards _openingCards;
    [SerializeField] private EndGame _endGame;

    public void Next()
    {
        GetComponent<Animator>().Rebind();
        _shufflingDeck.ArrayCard[NumberCard] = _shufflingDeck.ArrayCard[_shufflingDeck.nextCard];
        _shufflingDeck.nextCard++;
        _openingCards.ViewCard();
        _endGame.CheckEndGame(true, 1.5f);
    }
}
