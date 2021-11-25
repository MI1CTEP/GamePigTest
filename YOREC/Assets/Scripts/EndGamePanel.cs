using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    [HideInInspector] public bool Win;
    [HideInInspector] public int Winning;
    [SerializeField] private Text _winningText;
    [SerializeField] private Text _cash;
    [SerializeField] private Image _cap;
    [SerializeField] private Button _next;
    [SerializeField] private GameObject _mem;
    private int _seriesOfDefeats;

    private void OnEnable()
    {
        _seriesOfDefeats = PlayerPrefs.GetInt("SOD");
        PlayerPrefs.SetInt("CASH", PlayerPrefs.GetInt("CASH") + Winning);
        _cash.text = PlayerPrefs.GetInt("CASH").ToString();
        if (Winning == 0)
        {
            _winningText.text = "LOSE";
            _cap.color = new Color(0, 0, 0);
            _seriesOfDefeats++;
        }
        else
        {
            _winningText.text = "WIN " + Winning.ToString();
            _cap.color = new Color(1, 1, 1);
            _seriesOfDefeats = 0;
        }

        if (_seriesOfDefeats >= 3)
        {
            _mem.SetActive(true);
            _seriesOfDefeats = 0;
        }

        PlayerPrefs.SetInt("SOD", _seriesOfDefeats);

        if (PlayerPrefs.GetInt("CASH") < PlayerPrefs.GetInt("BET"))
            _next.interactable = false;
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene(0);
    }
}
