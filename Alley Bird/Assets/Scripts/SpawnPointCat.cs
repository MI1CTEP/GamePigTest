using UnityEngine;

public class SpawnPointCat : MonoBehaviour
{
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _positionY;

    public void Go()
    {
        float randomPositionX = Random.Range(_minPositionX, _maxPositionX);
        transform.localPosition = new Vector3(randomPositionX, _positionY, -0.01f);
    }
}