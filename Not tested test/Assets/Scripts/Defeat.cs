using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    public void Death()
    {
        Time.timeScale = 0;
        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
