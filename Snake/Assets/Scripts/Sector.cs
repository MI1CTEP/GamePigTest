using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private MeshRenderer _checkpoint;
    [SerializeField] private Spawner[] _spawners;

    private Color _color;
    private Color _poisonColor;

    public void SetParameters(Color color)
    {
        _checkpoint.material.color = color;
        _color = color;
        _poisonColor = Colors.GetRandom(_color);
        SpawnEatAdnPoison();
    }

    private void SpawnEatAdnPoison()
    {
        foreach (var spawner in _spawners)
        {
            spawner.Spawn(_color, _poisonColor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Segment>(out Segment segment))
        {
            segment.SetColor(_color);
        }
        if (other.TryGetComponent<SectorGenerator>(out SectorGenerator generator))
        {
            generator.Generate();
        }
    }
}
