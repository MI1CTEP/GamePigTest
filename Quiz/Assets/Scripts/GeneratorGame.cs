using UnityEngine;
using UnityEngine.Events;

public class GeneratorGame : MonoBehaviour
{
    [SerializeField] private int _maxCell;
    [SerializeField] private int _cellsPerLevel;
    [SerializeField] private ArrayCells _arrayCells;
    [SerializeField] private Game[] _games;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private GameObject _loadWindow;

    [SerializeField] private UnityEventSpriteArray StartGameSprite;
    [SerializeField] private UnityEventStringArray StartGameString;

    private int _contentsQuantity;
    private int _lvl;
    private int[] _answers;

    private void Start()
    {
        int random = Random.Range(0, _games.Length);
        _contentsQuantity = _games[random].ContentsQuantity;

        StartGameSprite.Invoke(_games[random].Spritecontent);
        StartGameString.Invoke(_games[random].NameContent);

        if (_maxCell > _contentsQuantity)
            _maxCell = _contentsQuantity;
        if (_cellsPerLevel > _maxCell)
            _cellsPerLevel = _maxCell;

        _arrayCells.CreateArray(_maxCell);

        GenerateAnswers();

        NextLevel();
    }

    private void GenerateAnswers()
    {
        _lvl = 0;
        _answers = IntArray.CreateRandom(_contentsQuantity);
    }

    public void NextLevel()
    {
        _lvl++;

        if (_lvl * _cellsPerLevel > _maxCell)
        {
            _loadWindow.SetActive(true);
        }
        else
        {
            _arrayCells.CreateCells(_cellsPerLevel);
            _arrayCells.CreateContentInCell(this, _answers[_lvl - 1]);
        }
    }

    public void ParticlePlay()
    {
        _particle.Play();
    }
}
[System.Serializable]
public class UnityEventSpriteArray : UnityEvent<Sprite[]> { }

[System.Serializable]
public class UnityEventStringArray : UnityEvent<string[]> { }
