using UnityEngine;
using DG.Tweening;

public class Resource_3_anim : MonoBehaviour
{
    [SerializeField] private Transform _leftLever;
    [SerializeField] private Transform _rightLever;

    public void Play(float time)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(_leftLever.DORotate(new Vector3(0, -90, 0), time));
        sequence.Join(_rightLever.DORotate(new Vector3(0, 90, 180), time));
        sequence.Append(_leftLever.DORotate(new Vector3(0, 0, 0), 0));
        sequence.Join(_rightLever.DORotate(new Vector3(0, 0, 180), 0));
    }
}