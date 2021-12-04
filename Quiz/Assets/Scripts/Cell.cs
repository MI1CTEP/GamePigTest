using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _content;
    [SerializeField] private EaseInBounce _easeInBounce;
    [SerializeField] private Bounce _bounce;

    private GeneratorGame _generatorGame;

    public void Subscribe(GeneratorGame generatorGame)
    {
        _generatorGame = generatorGame;
    }

    public void CreateContent(Sprite sprite)
    {
        _generatorGame = null;
        _content.sprite = sprite;
        _content.transform.localScale = new Vector3(sprite.rect.width / sprite.rect.height, 1, 1);
    }

    public void ClickToCell()
    {
        if (_generatorGame == null)
            _easeInBounce.Play();
        else
        {
            _generatorGame.ParticlePlay();
            _bounce.Play(this);
        }
    }

    public void NextLevel()
    {
        _generatorGame.NextLevel();
    }
}
