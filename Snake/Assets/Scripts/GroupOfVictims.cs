using UnityEngine;

public class GroupOfVictims : MonoBehaviour
{
    [SerializeField] private int _quantity;

    private Vector3[] _pointsSpawn;

    public void Spawn(GameObject man, Color color)
    {
        _pointsSpawn = new Vector3[9];

        for (int x = 1, i = 0; x > -2; x--)
            for (int z = 1; z > -2; z--, i++)
                _pointsSpawn[i] = new Vector3(x, 0, z);

        int[] random = ArrayRandom.Create(9);

        for (int i = 0; i < _quantity; i++)
        {
            GameObject manClone = Instantiate(man, transform.position + _pointsSpawn[random[i]], Quaternion.identity, transform);
            manClone.GetComponent<MeshRenderer>().material.color = color;
        }
    }
}
