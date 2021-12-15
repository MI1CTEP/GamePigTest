using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Platform : MonoBehaviour
{
    [SerializeField] private NewPos OnNewPosition;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            if (player.transform.position.y > transform.position.y)
            {
                _collider.isTrigger = false;
                player.OnNextPlatform.Invoke();
            }
        }
    }

    public void NewPosition(int chanceSpawnCat)
    {
        int random = Random.Range(0, 100);
        bool isSpawn = false;
        if (random < chanceSpawnCat) 
            isSpawn = true;
        OnNewPosition.Invoke(transform, isSpawn);
    }
}

[System.Serializable]
public class NewPos : UnityEvent<Transform, bool> { }