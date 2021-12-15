using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public void Go()
    {
        SceneManager.LoadScene(0);
    }
}