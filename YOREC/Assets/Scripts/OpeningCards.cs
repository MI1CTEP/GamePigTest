using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpeningCards : MonoBehaviour
{
    [SerializeField] private Animator[] _cardAnim;
    [SerializeField] private Image[] _card;
    [SerializeField] private Sound _sound;
    private ShufflingDeck _shufflingDeck;

    private void Start()
    {
        _shufflingDeck = GetComponent<ShufflingDeck>();
        ViewCard();
        StartCoroutine(AnimationCard());
    }

    public void ViewCard()
    {
        for (int i = 0; i < 4; i++)
            _card[i].sprite = _shufflingDeck.Card[_shufflingDeck.ArrayCard[i]];
    }

    IEnumerator AnimationCard()
    {
        for (int i = 0; i < _cardAnim.Length; i++)
        {
            _sound.PlayCard();
            _cardAnim[i].enabled = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
