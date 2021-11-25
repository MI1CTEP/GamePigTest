using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Combinations : MonoBehaviour
{
    [SerializeField] private Text _multiplierText;
    private int _multiplier;
    private int[] _card = new int[4];
    private int[] _cardSuit = new int[4];
    private int[] _cardValue = new int[4];

    private void Start()
    {
        StartCoroutine(Wait());
        CheckCombination();
    }
    public int CheckCombination()
    {
        for (int i = 0; i < _card.Length; i++)
        {
            _card[i] = GetComponent<ShufflingDeck>().ArrayCard[i];
            _cardSuit[i] = _card[i] / 13;
            _cardValue[i] = _card[i] % 13;
        }

        if (_cardValue[0] == _cardValue[1] && _cardValue[0] == _cardValue[2] && _cardValue[0] == _cardValue[3])
        {
            if (_cardValue[0] == 0)
                _multiplier = 50;
            else if (_cardValue[0] > 9)
                _multiplier = 35;
            else if (_cardValue[0] < 10)
                _multiplier = 25;
        }
        else if (_cardSuit[0] == _cardSuit[1] && _cardSuit[0] == _cardSuit[2] && _cardSuit[0] == _cardSuit[3])
            _multiplier = 10;
        else if (_cardValue[0] == _cardValue[1] && _cardValue[2] == _cardValue[3] || _cardValue[0] == _cardValue[2] && _cardValue[1] == _cardValue[3] || _cardValue[0] == _cardValue[3] && _cardValue[1] == _cardValue[2])
            _multiplier = 7;
        else if (_cardSuit[0] == _cardSuit[1] && _cardSuit[2] == _cardSuit[3] || _cardSuit[0] == _cardSuit[2] && _cardSuit[1] == _cardSuit[3] || _cardSuit[0] == _cardSuit[3] && _cardSuit[1] == _cardSuit[2])
            _multiplier = 5;
        else if (_cardSuit[0] != _cardSuit[1] && _cardSuit[0] != _cardSuit[2] && _cardSuit[0] != _cardSuit[3] && _cardSuit[1] != _cardSuit[2] && _cardSuit[1] != _cardSuit[3] && _cardSuit[2] != _cardSuit[3])
            _multiplier = 2;
        else
            _multiplier = 0;
        return _multiplier;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        MultiplierView();
    }

    public void MultiplierView()
    {
        _multiplierText.text = "X" + _multiplier.ToString();
    }
}
