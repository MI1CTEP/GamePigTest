using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    [SerializeField] private GameObject _winText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SectorGenerator>())
        {
            _endPanel.SetActive(true);
            _winText.SetActive(true);
        }
    }
}