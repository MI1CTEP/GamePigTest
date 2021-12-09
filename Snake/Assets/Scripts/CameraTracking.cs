using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] private Transform _object;

    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _startPosition + new Vector3(0, 0, _object.position.z);
    }
}
