using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Open()
    {
        _panel.SetActive(true);
    }

    public void Close()
    {
        _panel.SetActive(false);
    }
}
