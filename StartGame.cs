using UnityEngine;

public class StartGame : MonoBehaviour
{
    private float _cameraMove;
    private bool _start;
    [SerializeField] private Transform _camera;

    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _interface;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartIntro()
    {
        _start = true;
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (!_start)
            return;

        _cameraMove += 0.01f;
        _camera.position = new Vector3((-8.5f + 8.5f * _cameraMove), (0.5f + 10.5f * _cameraMove), (-0.5f - 9.5f * _cameraMove));
        _camera.rotation = Quaternion.Euler ((1 + 61 * _cameraMove), (-90 + 90 * _cameraMove), (-5 + 5 * _cameraMove));

        _startPanel.transform.Translate(-10, 0, 0, Space.World);

        if (_cameraMove >= 1)
        {
            _start = false;
            _startPanel.SetActive(false);
            _interface.SetActive(true);
        }
    }
}
