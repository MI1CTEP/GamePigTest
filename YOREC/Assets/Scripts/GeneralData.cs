using UnityEngine;
using UnityEngine.UI;

public class GeneralData : MonoBehaviour
{
    [SerializeField] private Text _cashText;
    private int _cash;

    private void Start()
    {
        if (PlayerPrefs.GetInt("OLD") == 0)
        {
            PlayerPrefs.SetInt("CASH", 500);
            PlayerPrefs.SetInt("OLD", 1);
            PlayerPrefs.SetInt("BET", 4);
        }
        _cash = PlayerPrefs.GetInt("CASH");
        _cashText.text = _cash.ToString();
    }
}
