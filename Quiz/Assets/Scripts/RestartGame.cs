using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _loadScale;
    [SerializeField] private Image _background;
    [SerializeField] private Image _progressBar;

    private void Start()
    {
        _background.DOColor(new Color(0, 0, 0, 0.5f), 0.5f);
        _restartButton.SetActive(true);
    }

    public void Restart()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(_background.DOColor(new Color(0, 0, 0, 1), 0.5f));
        sequence.OnComplete(LoadScene);
    }

    private void LoadScene()
    {
        StartCoroutine(Load());
        _loadScale.SetActive(true);
    }

    IEnumerator Load()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(0);
        while (!async.isDone)
        {
            _progressBar.fillAmount = async.progress;
            yield return null;
        }
    }
}
