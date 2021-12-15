using UnityEngine;

public class Cat : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            player.OnDeath.Invoke();
    }
}