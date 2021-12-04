using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _forse;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transform;

    public void Play(Cell cell)
    {
        var sequence = DOTween.Sequence();
        for (int i = 16; i > 1; i /= 2)
        {
            sequence.Append(_transform.DOLocalMoveY(_forse * i, 1 / _speed));
            sequence.Append(_transform.DOLocalMoveY(0, 1 / _speed));
        }
        sequence.OnComplete(cell.NextLevel);
    }
}
