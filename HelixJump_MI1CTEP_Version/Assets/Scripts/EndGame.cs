using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private PassageTrigger _passageTrigger;
    [SerializeField] private BallJump _ballJump;
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Text _message;
    [SerializeField] private Text _pointsScored;
    [SerializeField] private Text _blowsText;
    [SerializeField] private Score _score;
    private int _blows = 10;

    private void OnEnable()
    {
        UpdateBlowText();
        _passageTrigger.SectorPassed += PlusBlow;
        _ballJump.Jump += MinusBlow;
    }

    public void MinusBlow()
    {
        if (enabled)
        {
            _blows -= 2;
            UpdateBlowText();
            if (_blows <= 1)
            {
                _passageTrigger.SectorPassed -= PlusBlow;
                _ballJump.Jump -= MinusBlow;
                StartCoroutine(End());
            }
        }
    }

    public void PlusBlow()
    {
        _blows++;
        UpdateBlowText();
    }

    private void UpdateBlowText()
    {
        _blowsText.text = (_blows / 2).ToString();
    }

    private IEnumerator End()
    {
        _endPanel.SetActive(true);
        if(_score.ScoreValue > PlayerPrefs.GetInt("RECORD"))
        {
            PlayerPrefs.SetInt("RECORD", _score.ScoreValue);
            _message.text = "New Record";
        }
        else
        {
            _message.text = "Score";
        }
        _pointsScored.text = _score.ScoreValue.ToString();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}

