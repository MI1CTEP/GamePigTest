using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speedMoved;

    private float _startPositionY;

    private void Awake()
    {
        _startPositionY = _transform.position.y;
    }

    private void LateUpdate()
    {
        _transform.localPosition = new Vector3(0,_startPositionY - transform.position.y * _speedMoved, 20);
    }
}