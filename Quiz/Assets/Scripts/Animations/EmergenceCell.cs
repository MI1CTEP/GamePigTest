using UnityEngine;
using DG.Tweening;

public class EmergenceCell : MonoBehaviour
{
    [SerializeField] private Transform _cellTransform;

    private void OnEnable()
    {
        var sequence = DOTween.Sequence();

        sequence.Append(_cellTransform.DOScale(1.1f, 0.3f));
        sequence.Append(_cellTransform.DOScale(1f, 0.2f));
    }
}
