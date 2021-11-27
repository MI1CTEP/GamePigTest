using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int ScoreValue { get; private set; }

    [SerializeField] private PassageTrigger _passageTrigger;
    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        _passageTrigger.SectorPassed += PlusScore;
    }

    public void PlusScore()
    {
        ScoreValue++;
        _scoreText.text = ScoreValue.ToString();
    }

    private void OnDisable()
    {
        _passageTrigger.SectorPassed -= PlusScore;
    }
}
