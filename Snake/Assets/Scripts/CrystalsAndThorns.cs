using UnityEngine;

public class CrystalsAndThorns : MonoBehaviour
{
    [SerializeField] private Transform[] _crystalsAndThorns;

    private void OnEnable()
    {
        int[] random = ArrayRandom.Create(3);

        for (int i = 0, p =12; i < 3; i++, p -= 12)
        {
            _crystalsAndThorns[random[i]].localPosition = new Vector3(0, 0, p); 
        }
    }
}