using UnityEngine;

public class SectorGenerator : MonoBehaviour
{
    [SerializeField] private Sector _sector;
    [SerializeField] private Transform _finish;
    [SerializeField] private int _sectorQuantity;

    private Sector _oldSectcor;
    private Sector _currentSector;
    private Color _colorOfCurrentSector = Color.white;
    private Vector3 _positionSector;

    private void Awake()
    {
        Generate();
    }

    public void Generate()
    {
        if (_oldSectcor != null)
            Destroy(_oldSectcor.gameObject);

        _oldSectcor = _currentSector;

        if (_sectorQuantity > 0)
        {
            _colorOfCurrentSector = Colors.GetRandom(_colorOfCurrentSector);
            _currentSector = Instantiate(_sector, _positionSector, Quaternion.identity);
            _currentSector.SetParameters(_colorOfCurrentSector);
            _positionSector += new Vector3(0, 0, _currentSector.transform.localScale.z * 10);
            _sectorQuantity--;
        }
        else
        {
            _finish.position = _positionSector;
        }
    }
}