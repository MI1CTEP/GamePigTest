using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_joystick.isActiveAndEnabled)
        {
            Vector3 move = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
            _characterController.Move(move * _speed * Time.deltaTime);
            transform.LookAt(move + transform.position);
        }
    }
}