using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Transform _door;
    private int _quantityEnemies;

    private void Start()
    {
        _quantityEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    public void CheckQuantityEnemies()
    {
        _quantityEnemies--;
        if(_quantityEnemies <= 0)
        {
            _door.localScale = new Vector3(4, 1, 1);
            _door.position = new Vector3(0, 5, 10.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            PlayerPrefs.SetInt("COIN", GetComponent<QuantityOfCoins>().coin);
            SceneManager.LoadScene(0);
        }
    }
}
