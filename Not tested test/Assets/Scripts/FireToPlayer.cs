using System.Collections;
using UnityEngine;

public class FireToPlayer : MonoBehaviour
{
    public float shootingSpeed;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _spawnPoint;
    private Transform _player;

    IEnumerator Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            Instantiate(_projectile, _spawnPoint.position, _body.rotation);
            yield return new WaitForSeconds(shootingSpeed);
        }
    }
    private void Update()
    {
        _body.LookAt(new Vector3(_player.position.x, 1, _player.position.z));
    }
}
