using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _force;

    private int _quantityOfJumps = 2;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            _quantityOfJumps = 2;
        }
    }

    public void Go()
    {
        if(_quantityOfJumps > 0)
        {
            Vector2 direction = new Vector2(0, _force);
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.AddForce(direction, ForceMode2D.Impulse);
            _quantityOfJumps--;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Go();
    }
}