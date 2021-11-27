using UnityEngine;

public class TowerUpdate : MonoBehaviour
{
    public void Rebuild()
    {
        DestroyOldSector();
        SpawnNewSector();
    }

    private void SpawnNewSector()
    {
        transform.root.GetComponent<TowerBuider>().Build();
    }

    private void DestroyOldSector()
    {
        Destroy(transform.parent.gameObject);
    }
}
