using UnityEngine;
using UnityEngine.UI;

public class RecordAndScore : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _recordText;

    private int _score;

    private void Awake()
    {
        _scoreText.text = "0";
        _recordText.text = $"RECORD: {PlayerPrefs.GetInt("RECORD")}";
    }
    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

    public void SaveRecord()
    {
        if (_score > PlayerPrefs.GetInt("RECORD"))
            PlayerPrefs.SetInt("RECORD", _score);
    }
}