using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Notifications : MonoBehaviour
{
    [SerializeField] private GameObject _notificationText;
    [SerializeField] private float _lifeTimeNotification;

    private string _notification;

    public void WarehouseIsFull(string nameWarehouse)
    {
        _notification = $"Склад {nameWarehouse} переполнен";
        InstantiateText();
    }

    public void IsNoFuel(string nameWarehouse, string nameFuel)
    {
        _notification = $"На складе {nameWarehouse} закончилось топливо {nameFuel}";
        InstantiateText();
    }

    private void InstantiateText()
    {
        GameObject notification = Instantiate(_notificationText, transform);
        notification.GetComponent<Text>().text = _notification;
        StartCoroutine(DeleteNotification(notification));
    }

    IEnumerator DeleteNotification(GameObject notification)
    {
        yield return new WaitForSeconds(_lifeTimeNotification);
        Destroy(notification);
    }
}