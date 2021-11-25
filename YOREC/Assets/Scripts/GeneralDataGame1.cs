using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GeneralDataGame1 : MonoBehaviour
{
    [SerializeField] private Text _cashText;
    [SerializeField] private Text _betText;
    private int _cash;
    private int _bet;

    private void Start()
    {
        _cash = PlayerPrefs.GetInt("CASH");
        _bet = PlayerPrefs.GetInt("BET");
        _cashText.text = _cash.ToString();
        _betText.text = _bet.ToString();
    }

    public int BetUpdate(bool recalculateBet)
    {
        if (recalculateBet)
        {
            _bet -= PlayerPrefs.GetInt("BET") / 4;
            _betText.text = _bet.ToString();
        }
        return _bet;
    }
}
