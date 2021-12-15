using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject _score;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _score.SetActive(true);
            Destroy(gameObject);
        }
    }
}