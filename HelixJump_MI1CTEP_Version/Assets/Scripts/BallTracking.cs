using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private float _ballMinPositionY;
    private Vector3 _startCameraPosition;

    private void Awake()
    {
        _startCameraPosition = _camera.transform.position;
        _ballMinPositionY = transform.position.y;
    }

    private void LateUpdate()
    {
        if(transform.position.y < _ballMinPositionY)
            _ballMinPositionY = transform.position.y;

        _camera.transform.position = _startCameraPosition + new Vector3(0, _ballMinPositionY, 0);
    }
}
