using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _crystalsText;
    [SerializeField] private Text _killsText;
    [SerializeField] private GameObject _restartPanel;

    private int _crystals;
    private int _kills;

    private void Start()
    {
        Time.timeScale = 1;
        _crystalsText.text = _crystals.ToString();
        _killsText.text = _kills.ToString();
    }

    public void UpdateCrystal()
    {
        _crystals++;
        _crystalsText.text = _crystals.ToString();
    }

    public void UpdateKills()
    {
        _kills++;
        _killsText.text = _kills.ToString();
    }

    public void SetActiveRestartPanel()
    {
        _restartPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}