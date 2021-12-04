using UnityEngine;

public class ArrayCells : MonoBehaviour
{
    [SerializeField] private GeneratorContent _generatorContent;
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Transform _panelCells;

    private Cell[] _cells;
    private int _createdCells;

    public void CreateArray(int lenght)
    {
        _cells = new Cell[lenght];
    }

    public void CreateCells(int quantity)
    {
        if (_createdCells + quantity > _cells.Length)
            quantity = _cells.Length - _createdCells;
        for (int i = 0; _createdCells + i < _createdCells + quantity; i++)
        {
            _cells[_createdCells + i] = Instantiate(_cellPrefab, _panelCells);
        }
        _createdCells += quantity;
    }

    public void CreateContentInCell(GeneratorGame generatorGame, int answer)
    {
        Sprite[] content = _generatorContent.Generate(_createdCells, ref answer);
        for (int i = 0; i <_createdCells; i++)
        {
            _cells[i].CreateContent(content[i]);
            if (i == answer)
                _cells[i].Subscribe(generatorGame);
        }
    }
}
