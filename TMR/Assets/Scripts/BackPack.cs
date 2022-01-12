using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackPack : MonoBehaviour
{
    [SerializeField] private Transform _backpack;
    [SerializeField] private int _capacity;
    [SerializeField] private float _foldingTime;

    [SerializeField] private UnityEventIntInt OnOpenBackPack;

    private Stack<Transform>[] _resources = new Stack<Transform>[3];
    private int[] _quantityResources = new int[3];
    private int _quantityResourcesAll;
    private bool inWarehouse;

    private void Awake()
    {
        for (int i = 0; i < _resources.Length; i++)
            _resources[i] = new Stack<Transform>(_capacity);
    }

    private void OnTriggerEnter(Collider other)
    {
        inWarehouse = true;
        if (other.TryGetComponent<FuelWarehouse>(out FuelWarehouse fuelWarehouse))
        {
            StartCoroutine(Give(fuelWarehouse));
        }
        else if (other.TryGetComponent<Warehouse>(out Warehouse warehouse))
        {
            StartCoroutine(Take(warehouse));
        }
    }

    private IEnumerator Give(FuelWarehouse fuelWarehouse)
    {
        int resourceId = fuelWarehouse.ResourceId;

        while (inWarehouse)
        {
            if (!fuelWarehouse.CheckFullness() && _quantityResources[resourceId] > 0)
            {
                fuelWarehouse.Put();
                Destroy(_resources[resourceId].Pop().gameObject);
                _quantityResourcesAll--;
                _quantityResources[resourceId]--;
                OnOpenBackPack.Invoke(resourceId, _quantityResources[resourceId]);
            }
            yield return new WaitForSeconds(_foldingTime);
        }
    }

    private IEnumerator Take(Warehouse warehouse)
    {
        int resourceId = warehouse.ResourceId;

        while (inWarehouse)
        {
            if(_quantityResourcesAll < _capacity)
            {
                Transform resourse = warehouse.Give();
                if (resourse != null)
                {
                    _resources[resourceId].Push(resourse);
                    _quantityResourcesAll++;
                    _quantityResources[resourceId]++;
                    OnOpenBackPack.Invoke(resourceId, _quantityResources[resourceId]);

                    resourse.SetParent(_backpack);
                    resourse.localPosition = Vector3.zero;
                    resourse.localRotation = Quaternion.identity;
                }
            }
            yield return new WaitForSeconds(_foldingTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inWarehouse = false;
    }
}

[Serializable]
public class UnityEventIntInt : UnityEvent<int, int> { }