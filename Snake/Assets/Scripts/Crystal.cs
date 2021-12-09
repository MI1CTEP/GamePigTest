using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mouth>(out Mouth mouth))
        {
            mouth.OnPickedUpCrystal.Invoke();
            Destroy(gameObject);
        }
    }
}