using System;
using UnityEngine;
using UnityEngine.Events;

public class FuelWarehouse : Warehouse
{
    [SerializeField] private string _fuelName;
    [SerializeField] private UnityEventStringString OnIsNoFuel;

    public bool CheckFuel()
    {
        if (_resources.Count > 0)
        {
            _checked = false;
            return true;
        }
        else
        {
            if (!_checked)
            {
                OnIsNoFuel.Invoke(_nameWarehouse, _fuelName);
                _checked = true;
            }
            return false;
        }
    }

    public void GiveFuel()
    {
        Destroy(_resources.Pop().gameObject);
    }
}

[Serializable]
public class UnityEventStringString : UnityEvent<string, string> { }