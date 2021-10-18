using System.Collections;
using UnityEngine;

public class AttackEnemyFlying : MonoBehaviour
{
    public float speed;
    public float shootingSpeed;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _spawnPoint;
    private Transform _player;
    private bool _attack;

    IEnumerator Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            _attack = true;
            yield return new WaitForSeconds(shootingSpeed);
        }
    }

    private void Update()
    {
        transform.LookAt(new Vector3(_player.position.x, 1, _player.position.z));
        if ((transform.position - _player.position).magnitude > 7)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        else if (_attack)
        {
            Instantiate(_projectile, _spawnPoint.position, transform.rotation);
            _attack = false;
        }
    }
}
