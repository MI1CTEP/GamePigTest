using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void Start()
    {
        GetComponent<Camera>().orthographicSize = Screen.height * 5.4f / Screen.width;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.position.z - 5);
    }
}
