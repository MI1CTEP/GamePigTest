using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveRicochet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private UnityEvent OnRicochet;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            _speed = -_speed;
            OnRicochet.Invoke();
        }
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime, 0, 0);
    }
}