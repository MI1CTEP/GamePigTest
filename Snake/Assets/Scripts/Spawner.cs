using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GroupOfVictims _group;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject _food;
    [SerializeField] private GameObject _poison;

    public void Spawn(Color eatColor, Color poisonColor)
    {
        int random = Random.Range(0, 2);

        switch (random)
        {
            case 0:
                InstantiateObject(_food, eatColor);
                break;
            case 1:
                InstantiateObject(_poison, poisonColor);
                break;
        }
    }

    private void InstantiateObject(GameObject man, Color color)
    {
        int randomPosition = Random.Range(0, _points.Length);
        GroupOfVictims group = Instantiate(_group, _points[randomPosition].position, Quaternion.identity, transform);
        group.Spawn(man, color);
    }
}