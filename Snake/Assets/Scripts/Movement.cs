using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Tail _tail;
    [SerializeField] private float _feverSpeedMultiplier;
    [SerializeField] private float _speed;
    [Range(0,1)]
    [SerializeField] private float _lateralSpeed;

    private Vector3 _vectorMove;
    private float _screenWidth;
    private float _vectorMoveX;
    private bool _control = true;

    private void Awake()
    {
        _screenWidth = Screen.width;
    }

    public void FeverMode(bool isActive)
    {
        if (isActive)
        {
            _control = false;
            _speed *= _feverSpeedMultiplier;
        }
        else
        {
            _control = true;
            _speed /= _feverSpeedMultiplier;
        }
    } 

    private void Update()
    {
        if (_control && Input.GetKey(KeyCode.Mouse0))
        {
            _vectorMoveX = (Input.mousePosition.x - _screenWidth / 2) * 17 / _screenWidth;
            Move();
        }
        else if (!_control)
        {
            _vectorMoveX = 0;
            Move();
        }

        _tail.Move(transform.position, _speed * Time.deltaTime);

        transform.Translate(0, 0, _speed * Time.deltaTime);
    }

    private void Move()
    {
        _vectorMove = new Vector3(_vectorMoveX, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, _vectorMove, _lateralSpeed);
    }
}