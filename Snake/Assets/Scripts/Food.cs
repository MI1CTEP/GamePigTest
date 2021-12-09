using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mouth>(out Mouth mouth))
        {
            mouth.Digestion();
            Destroy(gameObject);
        }
    }
}