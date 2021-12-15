using UnityEngine;

public class CameraScale : MonoBehaviour
{
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = 4.05f * Screen.height / Screen.width;
    }
}