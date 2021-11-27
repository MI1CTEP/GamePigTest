using UnityEngine;
using UnityEngine.Events;

public class PassageTrigger : MonoBehaviour
{
    public event UnityAction SectorPassed;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<TowerUpdate>(out TowerUpdate towerUpdate))
        {
            towerUpdate.Rebuild();
            SectorPassed?.Invoke();
        }
    }
}
