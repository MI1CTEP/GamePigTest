using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Factory : MonoBehaviour
{
    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private FuelWarehouse[] _fuelWarehouses;
    [SerializeField] private float _productionTime;
    [SerializeField] private bool _needFuel;

    [SerializeField] private UnityEventFloat OnProduce;

    private void Start()
    {
        StartCoroutine(Produce(true));
    }

    private IEnumerator Produce(bool repeat)
    {
        while (repeat)
        {
            if (_needFuel)
            {
                for (int i =0; i < _fuelWarehouses.Length; i++)
                    if (!_fuelWarehouses[i].CheckFuel())
                    {
                        yield return new WaitForSeconds(2);
                        goto Restart;
                    }
                for (int i = 0; i < _fuelWarehouses.Length; i++)
                    _fuelWarehouses[i].GiveFuel();
            }
            OnProduce.Invoke(_productionTime);
            yield return new WaitForSeconds(_productionTime);
            _warehouse.Put();
            repeat = !_warehouse.CheckFullness();

        Restart: continue;
        }
        StartCoroutine(CheckWarehouse(true));
    }

    private IEnumerator CheckWarehouse(bool check)
    {
        while (check)
        {
            yield return new WaitForSeconds(2);
            check = _warehouse.CheckFullness();
        }
        StartCoroutine(Produce(true));
    }
}

[Serializable]
public class UnityEventFloat : UnityEvent<float> { }