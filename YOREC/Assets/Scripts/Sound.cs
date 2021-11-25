using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound1;
    [SerializeField] private AudioSource _sound2;
    [SerializeField] private Image _button;

    private void Start()
    {
        CheckSound();
    }

    public void CheckSound()
    {
        if (PlayerPrefs.GetInt("SOUND") == 0)
        {
            _sound1.volume = 1;
            _sound2.volume = 1;
            _button.color = new Color(1, 1, 1);
        }
        else
        {
            _sound1.volume = 0;
            _sound2.volume = 0;
            _button.color = new Color(1, 0, 1);
        }
    }

    public void PlayButton()
    {
        _sound1.Play();
    }

    public void PlayCard()
    {
        _sound2.Play();
    }
}
