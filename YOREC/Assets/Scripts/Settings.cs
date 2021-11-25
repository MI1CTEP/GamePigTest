using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private Sound _sound;
    private AudioSource _music;
    [SerializeField] private Image _button;

    private void Awake()
    {
        _music = FindObjectOfType<Music>().GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("MUSIC") == 0)
        {
            _music.enabled = true;
            _button.color = new Color(1, 1, 1);
        }
        else
        {
            _music.enabled = false;
            _button.color = new Color(1, 0, 1);
        }
    }

    public void ChangeMusic()
    {
        if (PlayerPrefs.GetInt("MUSIC") == 0)
        {
            PlayerPrefs.SetInt("MUSIC", 1);
            _music.enabled = false;
            _button.color = new Color(1, 0, 1);
        }
        else
        {
            PlayerPrefs.SetInt("MUSIC", 0);
            _music.enabled = true;
            _button.color = new Color(1, 1, 1);
        }
    }

    public void ChangeSounds()
    {
        if (PlayerPrefs.GetInt("SOUND") == 0)
            PlayerPrefs.SetInt("SOUND", 1);
        else
            PlayerPrefs.SetInt("SOUND", 0);
        _sound.CheckSound();
    }

    public void DeleteSaves()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
