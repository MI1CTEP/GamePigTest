using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private GameObject _joystick;

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        int i = 3;
        bool farther = true;
        Time.timeScale = 0;
        while (farther)
        {
            _timeText.text = i.ToString();
            yield return new WaitForSecondsRealtime(1);
            i--;
            if (i == 0)
                farther = false;
        }
        Time.timeScale = 1;
        _timeText.enabled = false;
        _joystick.SetActive(true);
    }
}
