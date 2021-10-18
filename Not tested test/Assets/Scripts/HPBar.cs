using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Transform _hpBar;
    [SerializeField] private Transform _pointPosition;
    private Transform _parent;
    private Camera _camera;

    private void Start()
    {
        _parent = GameObject.FindGameObjectWithTag("HPCase").transform;
        _camera = Camera.main;
        _hpBar.SetParent(_parent);
    }

    private void Update()
    {
        Vector3 hpBarPosition = _camera.WorldToScreenPoint(_pointPosition.position);
        _hpBar.position = hpBarPosition;
    }
}
