using System;
using UnityEngine;

public class PigController : MonoBehaviour
{
    [SerializeField] private Joystick _joystickController;
    private CharacterController _charController;
    private bool _activeJoystick;
    public float _speed;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float joystickHor = _joystickController.Horizontal;
        float joystickVer = _joystickController.Vertical;

        Vector3 move = new Vector3(joystickHor * _speed * Time.deltaTime, 0, joystickVer * _speed * Time.deltaTime);
        _charController.Move(move);

        if (_activeJoystick)
        {
            if (joystickVer >= 0)
                transform.rotation = Quaternion.Euler(0, (180 + Math.Abs(joystickHor) * joystickHor * 90), 0);
            else
                transform.rotation = Quaternion.Euler(0, -(Math.Abs(joystickHor) * joystickHor * 90), 0);
        }
    }

    public void DownToJoystick()
    {
        _activeJoystick = true;
        GetComponent<InstallationBomb>().ResetActivated();
    }

    public void UpToJoystick()
    {
        _activeJoystick = false;
    }
}
