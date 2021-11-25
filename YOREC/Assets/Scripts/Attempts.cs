using UnityEngine;
using UnityEngine.UI;

public class Attempts : MonoBehaviour
{
    [SerializeField] private Text _attemptsText;
    private int _attempt = 4;

    private void Start()
    {
        MinusAttempt();
    }

    public int MinusAttempt()
    {
        _attempt--;
        _attemptsText.text = _attempt.ToString();
        return _attempt;
    }
}
