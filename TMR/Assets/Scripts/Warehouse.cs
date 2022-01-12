using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Warehouse : MonoBehaviour
{
    [SerializeField] protected string _nameWarehouse;
    [SerializeField] protected Resource _resource;
    [SerializeField] protected int _capacity;
    [SerializeField] protected int _resourceId;

    [SerializeField] private UnityEventString OnWarehouseIsFull;

    protected Stack<Resource> _resources;
    protected bool _checked;

    public int ResourceId => _resourceId;

    private void Awake()
    {
        _resources = new Stack<Resource>(_capacity);
    }

    public bool CheckFullness()
    {
        if (_resources.Count >= _capacity)
        {
            if (!_checked)
            {
                OnWarehouseIsFull.Invoke(_nameWarehouse);
                _checked = true;
            }
            return true;
        }
        else
        {
            _checked = false;
            return false;
        }
    }

    public void Put()
    {
        Resource resource = Instantiate(_resource, transform);
        _resources.Push(resource);
    }

    public Transform Give()
    {
        if (_resources.Count > 0)
            return _resources.Pop().transform;
        else
            return null;
    }
}

[Serializable]
public class UnityEventString : UnityEvent<string> { }