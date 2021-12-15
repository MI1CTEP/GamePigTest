using UnityEngine;

public class Sector : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private int _chanceSpawnCat;
    [SerializeField] private int _chanceSpawnCatStep;
    [SerializeField] private Collider2D[] _platforms;
    [SerializeField] private float _scaleY;

    public void NewPosition()
    {
        transform.position += new Vector3(0, _scaleY * 2, 0);
        UpdatePlatforms();
        _chanceSpawnCat += _chanceSpawnCatStep;
    }

    private void UpdatePlatforms()
    {
        foreach (var collider in _platforms)
        {
            collider.isTrigger = true;
            collider.GetComponent<Platform>().NewPosition(_chanceSpawnCat);
        }
    }
}