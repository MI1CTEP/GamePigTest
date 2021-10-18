using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public float hp;
    [SerializeField] private GameObject _hpBar;
    [SerializeField] private GameObject _chest;
    [SerializeField] private Image _imageHP;
    [SerializeField] private Text _textHP;
    private float _fullHP;

    private void Start()
    {
        _fullHP = hp;
        _textHP.text = hp.ToString("0");
    }

    public void CheckHP()
    {
        _textHP.text = hp.ToString("0");
        _imageHP.fillAmount = hp / _fullHP;
        if (hp <= 0)
        {
            Instantiate(_chest, transform.position, Quaternion.identity);
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Fire>().flag = false;
            player.GetComponent<EndGame>().CheckQuantityEnemies();

            if (gameObject.tag == "Player")
                GetComponent<Defeat>().Death();
            else
            {
                Destroy(gameObject);
                Destroy(_hpBar);
            }
        }
    }
}
