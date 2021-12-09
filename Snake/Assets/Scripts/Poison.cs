using UnityEngine;

public class Poison : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Mouth>(out Mouth mouth))
        {
            if (mouth.FeverMode)
                mouth.Digestion();
            else
                mouth.OnEatPoison.Invoke();

            Destroy(gameObject);
        }
    }
}