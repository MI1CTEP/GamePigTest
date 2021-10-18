using UnityEngine;

public class RandomObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] _obstacle;

    private void Awake()
    {
        int i = Random.Range(0, _obstacle.Length + 1);
        if (i != _obstacle.Length)
            _obstacle[i].SetActive(true);
    }
}
