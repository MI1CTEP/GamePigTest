using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _startCameraPosition;

    private void Awake()
    {
        _startCameraPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(_startCameraPosition.x, _startCameraPosition.y + _player.position.y, _startCameraPosition.z);
    }
}