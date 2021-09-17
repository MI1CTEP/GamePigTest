using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private Text _numberOfMurdersText;
    public int _numberOfMurders;

    public void Update()
    {
        _numberOfMurdersText.text = _numberOfMurders.ToString();
    }

    public void UpdateCounter()
    {
        _numberOfMurders++;
    }
}
