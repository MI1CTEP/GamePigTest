using UnityEngine;

public class PigDeath : MonoBehaviour
{
    [SerializeField] private GameObject _restartButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MoveEnemy>())
        {
            Time.timeScale = 0;
            _restartButton.SetActive(true);
        }
    }
}
