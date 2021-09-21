using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Text _timeToSpawn;
    [SerializeField] private Transform _enemy;
    public int _sec = 20;
    private int _msec;

    private void FixedUpdate()
    {
        _timeToSpawn.text = _sec.ToString("00");
        _msec++;
        if (_msec >= 50)
        {
            _sec--; 
            _msec = 0;
        }
        if (_sec == 0)
        {
            _enemy.position = new Vector3(10, 0.01f, 0);
            _enemy.rotation = Quaternion.Euler(0, -90, 0);
            Instantiate(_enemy);
            _sec = 20;
        }
    }
}
