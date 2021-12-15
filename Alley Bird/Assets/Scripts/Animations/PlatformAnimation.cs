using UnityEngine;
using DG.Tweening;

public class PlatformAnimation : MonoBehaviour
{
    [SerializeField] private Transform _transform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            var sequence = DOTween.Sequence();
            for (int i = 3; i > 0; i--)
            {
                sequence.Append(_transform.DOMoveY(_transform.position.y - 0.1f * i, 0.2f));
                sequence.Append(_transform.DOMoveY(_transform.position.y, 0.2f));
            }
        }
    }
}