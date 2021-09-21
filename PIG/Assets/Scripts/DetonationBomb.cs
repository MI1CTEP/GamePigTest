using UnityEngine;

public class DetonationBomb : MonoBehaviour
{
    private KillCounter _killCounter;

    private void Start()
    {
        _killCounter = FindObjectOfType<KillCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveEnemy>())
        {
            _killCounter.UpdateCounter();
            Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
