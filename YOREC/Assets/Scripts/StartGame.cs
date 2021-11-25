using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;

    public void OpenBetPanel()
    {
        _startPanel.SetActive(true);
    }

    public void StartGame1()
    {
        int cash = PlayerPrefs.GetInt("CASH") - PlayerPrefs.GetInt("BET");
        PlayerPrefs.SetInt("CASH", cash);
        SceneManager.LoadScene(1);
    }
}
