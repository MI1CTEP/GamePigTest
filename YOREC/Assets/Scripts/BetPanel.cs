using UnityEngine;
using UnityEngine.UI;

public class BetPanel : MonoBehaviour
{
    [SerializeField] private Slider _betValue;
    [SerializeField] private Text _betText;
    [SerializeField] private Button _play;

    private void OnEnable()
    {
        _betValue.minValue = 4;
        _betValue.maxValue = PlayerPrefs.GetInt("CASH");
        if (PlayerPrefs.GetInt("BET") > _betValue.maxValue)
            PlayerPrefs.SetInt("BET", (int)_betValue.maxValue);
        _betValue.value = PlayerPrefs.GetInt("BET");

        if (_betValue.maxValue < 4)
        {
            _betValue.maxValue = 4;
            _play.interactable = false;
        }
        else
        {
            _play.interactable = true;
        }

        ChangeBet();
    }

    public void ChangeBet()
    {
        _betText.text = _betValue.value.ToString();
    }

    public void SaveBet()
    {
        PlayerPrefs.SetInt("BET", (int)_betValue.value);
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
