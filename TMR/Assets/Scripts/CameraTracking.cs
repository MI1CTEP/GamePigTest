using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _object;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 objectPosition = new Vector3(_object.position.x, 0, _object.position.z);
        transform.position = _startPosition + objectPosition;
    }
}