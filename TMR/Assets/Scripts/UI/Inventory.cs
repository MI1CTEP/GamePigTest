using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Text[] _quantityText;

    private void Awake()
    {
        for (int i = 0; i < _quantityText.Length; i++)
            _quantityText[i].text = "0";
    }

    public void Show(int id, int quantity)
    {
        _quantityText[id].text = quantity.ToString();
    }
}