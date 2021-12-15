using UnityEngine;

public class SpawnCat : MonoBehaviour
{
    [SerializeField] private Cat[] _cats;
    [SerializeField] private int[] _chanceOfSpawn;

    private Cat _cat;
    private int _chanceSum;

    private void Awake()
    {
        for (int i = 0; i < _chanceOfSpawn.Length; i++)
            _chanceSum += _chanceOfSpawn[i];
    }

    public void Go(Transform parent, bool isSpawn)
    {
        ClearCat();
        if (isSpawn)
        {
            int random = Random.Range(1, _chanceSum + 1);
            int randomCat = RandomCat(random);
            _cat = Instantiate(_cats[randomCat], parent);
            _cat.GetComponent<SpawnPointCat>().Go();
        }
    }

    private int RandomCat(int random)
    {
        for (int i = 0; i < _chanceOfSpawn.Length; i++)
        {
            random -= _chanceOfSpawn[i];
            if (random <= 0)
                return i;
        }
        return 0;
    }

    private void ClearCat()
    {
        if (_cat != null) 
            Destroy(_cat.gameObject);
    }
}