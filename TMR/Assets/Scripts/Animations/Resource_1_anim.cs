using UnityEngine;
using DG.Tweening;

public class Resource_1_anim : MonoBehaviour
{
    public void Play(float time)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMoveY(transform.position.y + 1, time));
        sequence.Append(transform.DOMoveY(transform.position.y, 0));
    }
}