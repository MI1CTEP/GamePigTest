using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private string[] _nameContent;
    [SerializeField] private Sprite[] _spriteContent;

    public string[] NameContent => _nameContent;
    public Sprite[] Spritecontent => _spriteContent;

    public int ContentsQuantity => _spriteContent.Length;
}
