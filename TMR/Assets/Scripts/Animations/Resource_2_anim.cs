using UnityEngine;
using DG.Tweening;

public class Resource_2_anim : MonoBehaviour
{
    [SerializeField] private Material _materialStart;
    [SerializeField] private Material _materialEnd;
    [SerializeField] private Material _objectMaterial;

    private Color _colorStart;
    private Color _colorEnd;

    private void Awake()
    {
        _colorStart = _materialStart.color;
        _colorEnd = _materialEnd.color;
    }

    public void Play(float time)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DORotate(new Vector3(0, 134, 0), time));
        sequence.Join(_objectMaterial.DOColor(_colorEnd, time));
        sequence.Append(transform.DORotate(new Vector3(0, -45, 0), 0));
        sequence.Join(_objectMaterial.DOColor(_colorStart, 0));
    }
}