using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class IgnoreCollider : MonoBehaviour
{
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Wall>())
        {
            Physics2D.IgnoreCollision(_collider, collision.collider, true);
        }
    }
}