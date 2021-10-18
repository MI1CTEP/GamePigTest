using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _body;
    private Rigidbody _rigidbody;
    private Fire _fire;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _fire = GetComponent<Fire>();
    }

    public void PointerDown()
    {
        _fire.enabled = false;
    }

    public void PointerUp()
    {
        _fire.enabled = true;
    }

    private void Update()
    {
        float horizontal = _joystick.Horizontal * speed * Time.deltaTime;
        float vertical = _joystick.Vertical * speed * Time.deltaTime;
        Vector3 speedVector = new Vector3(horizontal, 0, vertical);

        _rigidbody.MovePosition(transform.position + speedVector);
        _body.transform.LookAt(transform.position + speedVector.normalized);
    }
}
