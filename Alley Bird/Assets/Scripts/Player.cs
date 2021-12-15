using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent OnDeath;
    public UnityEvent OnNextPlatform;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<Sector>(out Sector sector))
        {
            sector.NewPosition();
        }
    }
}