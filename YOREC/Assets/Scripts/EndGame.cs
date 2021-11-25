using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private Button[] _nextCard;
    [SerializeField] private Combinations _combinations;
    [SerializeField] private Attempts _attempts;
    [SerializeField] private GeneralDataGame1 _generalData;
    private int attempts = 1;

    private void Start()
    {
        CheckEndGame(false, 4);
    }

    public void CheckEndGame(bool multiplierView, float timeViewEndPanel)
    {
        int multiplier = _combinations.CheckCombination();
        if (multiplierView)
        {
            _combinations.MultiplierView();
            attempts = _attempts.MinusAttempt();
        }
        int bet = _generalData.BetUpdate(multiplierView);
        if (multiplier != 0)
        {
            End(true, multiplier * bet);
            StartCoroutine(ViewEndPanel(timeViewEndPanel));
            return;
        }
        if (attempts == 0)
        {
            End(false, 0);
            StartCoroutine(ViewEndPanel(timeViewEndPanel));
        }
    }

    private void End(bool win, int winning)
    {
        for (int i = 0; i < _nextCard.Length; i++)
            _nextCard[i].interactable = false;
        _endPanel.GetComponent<EndGamePanel>().Win = win;
        _endPanel.GetComponent<EndGamePanel>().Winning = winning;
    }

    IEnumerator ViewEndPanel(float timeViewEndPanel)
    {
        yield return new WaitForSeconds(timeViewEndPanel);
        _endPanel.SetActive(true);
    }
}
