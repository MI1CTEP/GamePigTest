using UnityEngine;

public class TowerBuider : MonoBehaviour
{
    [SerializeField] private GameObject[] _sector;
    [SerializeField] private Transform _cylinder;


    private int _platformHeight;

    private void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            Build();
        }
    }

    public void Build()
    {
        Vector3 position = new Vector3(0, _platformHeight, 0);
        Instantiate(RandomPlatform(), position, Quaternion.Euler(0, Random.Range(0, 12) * 30, 0), transform);
        _platformHeight -= 2;
        _cylinder.position = new Vector3(0, _platformHeight, 0);
    }

    private GameObject RandomPlatform()
    {
        int random = Random.Range(0, _sector.Length);
        return _sector[random];
    }
}
