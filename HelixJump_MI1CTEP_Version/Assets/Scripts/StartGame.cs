using System.Collections;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _startSector;
    [SerializeField] private TowerRotator _towerRotator;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private EndGame _endGame;

    public void Play()
    {
        _towerRotator.enabled = true;
        _playButton.SetActive(false);
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(2);
        Destroy(_startSector);
        _endGame.enabled = true;
    }
}
