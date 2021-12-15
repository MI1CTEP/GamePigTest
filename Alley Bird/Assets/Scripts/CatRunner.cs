using System.Collections;
using UnityEngine;

public class CatRunner : Cat
{
    [SerializeField] private SpriteRenderer _warningPrefab;
    [SerializeField] private float _speed;
    [Range(3, 10)]
    [SerializeField] private float _timeBetweenSpawns;

    private Vector3 _startPosition;
    private SpriteRenderer _warning;

    private void Start()
    {
        if (_timeBetweenSpawns < 3)
            _timeBetweenSpawns = 3;

        _startPosition = transform.position;

        _warning = Instantiate(_warningPrefab, _startPosition + new Vector3(1.7f, 1f, 0), Quaternion.identity);

        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetweenSpawns - 2);
            _warning.enabled = true;
            yield return new WaitForSeconds(2);
            _warning.enabled = false;
            transform.position = _startPosition;
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}