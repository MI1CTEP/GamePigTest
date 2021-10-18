using System.Collections;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public int enemy;
    public int enemyFlying;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _enemyFlying;

    private void Awake()
    {
        for (int i = 0; i < enemy; i++)
        {
            Vector3 random = new Vector3(Random.Range(-4, 4), 1, Random.Range(-2, 9));
            Instantiate(_enemy, random, Quaternion.Euler(0, 180, 0));
        }
        for (int i = 0; i < enemyFlying; i++)
        {
            Vector3 random = new Vector3(Random.Range(-4, 4), 1, Random.Range(-2, 9));
            Instantiate(_enemyFlying, random, Quaternion.Euler(0, 180, 0));
        }
        GetComponent<StartGame>().StartCountdown();
    }
}
