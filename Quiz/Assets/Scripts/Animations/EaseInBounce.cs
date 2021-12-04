using UnityEngine;
using DG.Tweening;

public class EaseInBounce : MonoBehaviour
{
    [SerializeField] private float _forse;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _transform;
    public void Play()
    {
        var sequence = DOTween.Sequence();
        for (int i = 3; i > 0; i--)
        {
            sequence.Append(_transform.DOLocalMoveX(_forse * i, 1 / _speed));
            sequence.Append(_transform.DOLocalMoveX(-_forse * i, 2 / _speed));
            sequence.Append(_transform.DOLocalMoveX(0, 1 / _speed));
        }
    }
}
