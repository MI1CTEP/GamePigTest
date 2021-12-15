using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Rotate : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    public void Go()
    {
        _sprite.flipX = !_sprite.flipX;
    }
}