using UnityEngine;
using UnityEngine.UI;

public class QuantityOfCoins : MonoBehaviour
{
    [HideInInspector] public int coin;
    [SerializeField] private Text _coinText;

    private void Start()
    {
        coin = PlayerPrefs.GetInt("COIN");
        _coinText.text = coin.ToString();
    }

    public void CoinPlus()
    {
        coin += 10;
        _coinText.text = coin.ToString();
    }
}
