using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private Transform _pig;
    private MoveEnemy[] _moveEnemy;

    public void Restart()
    {
        _moveEnemy = FindObjectsOfType<MoveEnemy>();

        for (int i = 0; i < _moveEnemy.Length; i++)
            Destroy(_moveEnemy[i].gameObject);

        GetComponent<SpawnEnemy>()._sec = 1;
        GetComponent<KillCounter>()._numberOfMurders = 0;

        _restartButton.SetActive(false);
        _pig.GetComponent<PigController>().enabled = true;

        Time.timeScale = 1;
    }
}
