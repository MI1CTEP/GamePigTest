using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [HideInInspector] public bool flag;

    [SerializeField] private Transform _body;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _projectile;

    private GameObject[] _enemy;
    private float _distanceToEnemy = 30;
    private int _nearEnemy = 0;

    private void OnEnable()
    {
        _enemy = GameObject.FindGameObjectsWithTag("Enemy");
        flag = true;
        if (_enemy.Length > 0)
        {
            StartCoroutine(TargetSelection());
            StartCoroutine(FireToEnemy());
        }
    }
    private void OnDisable()
    {
        _distanceToEnemy = 30;
        flag = false;
    }

    IEnumerator TargetSelection()
    {
        while (flag)
        {
            if (_enemy.Length > _nearEnemy)
                _enemy[_nearEnemy].GetComponent<StatusMark>().DeactiveMark();

            for (int i = 0; i < _enemy.Length; i++)
            {
                float distantion = (transform.position - _enemy[i].transform.position).magnitude;
                if (distantion < _distanceToEnemy)
                {
                    _distanceToEnemy = distantion;
                    _nearEnemy = i;
                }
            }

            _enemy[_nearEnemy].GetComponent<StatusMark>().ActiveMark();
            _body.transform.LookAt(new Vector3(_enemy[_nearEnemy].transform.position.x, 1, _enemy[_nearEnemy].transform.position.z));
            yield return new WaitForSeconds(0.5f);
        }
    }
    IEnumerator FireToEnemy()
    {
        while (flag)
        {
            Instantiate(_projectile, _spawnPoint.transform.position, _body.transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
