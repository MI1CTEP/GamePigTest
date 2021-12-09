using System.Collections;
using UnityEngine;

public class Fever : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    [SerializeField] private Mouth _mouth;
    [SerializeField] private int _timeBetweenCrystalsFixedFrame;
    [SerializeField] private int _timeFever;

    private Collider _collider;
    private Transform _transform;
    private bool _feverMode;
    private int _combo;
    private int _tBCFF;

    private void Start()
    {
        _tBCFF = _timeBetweenCrystalsFixedFrame;
        _collider = GetComponent<Collider>();
        _transform = GetComponent<Transform>();
    }

    public void CollectedCrystal()
    {
        if (!_feverMode)
        {
            _combo++;
            _tBCFF = _timeBetweenCrystalsFixedFrame;
        }

        if (_combo == 3)
        {
            _combo = 0;
            FeverMode(true);
            _transform.localScale *= 5;
            StartCoroutine(FeverModeActive());
        }
    }

    private void FixedUpdate()
    {
        if (_tBCFF > 0)
            _tBCFF -= 1;
        else if (_tBCFF == 0)
            _combo = 0;
    }

    private void FeverMode(bool isActive)
    {
        _feverMode = isActive;
        _movement.FeverMode(isActive);
        _mouth.FeverMode = isActive;
    }

    private IEnumerator FeverModeActive()
    {
        int timeFever = _timeFever;
        while(timeFever > 0)
        {
            yield return new WaitForSeconds(1);
            timeFever--;
        }
        FeverMode(false);
        _transform.localScale /= 5;
        StartCoroutine(TurnOffCollier());
    }

    private IEnumerator TurnOffCollier()
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }
}