using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceScanner))]
public class ResourceRegistry : MonoBehaviour
{
    private List<Resource> _freeResources = new List<Resource>();
    private List<Resource> _busyResources = new List<Resource>();
    private ResourceScanner _resourceScanner;
    private int _resourceIndex = 0;

    public event Action<Resource> ResourceDelivered;

    private void Awake()
    {
        _resourceScanner = GetComponent<ResourceScanner>();
    }

    public void Scan()
    {
        List<Resource> foundResources = _resourceScanner.Scan();

        foreach (Resource resource in foundResources)
        {
            if (_freeResources.Contains(resource) == false
                && _busyResources.Contains(resource) == false)
            {
                _freeResources.Add(resource);
            }
        }
    }

    public bool TryGetFreeResource(out Resource resource)
    {
        resource = null;

        if (_freeResources.Count == 0)
        {
            return false;
        }

        resource = _freeResources[_resourceIndex];

        _freeResources.RemoveAt(_resourceIndex);
        _busyResources.Add(resource);

        return true;
    }

    public void RemoveResource(Resource resource)
    {
        if (_busyResources.Remove(resource))
        {
            ResourceDelivered?.Invoke(resource);
        }
    }
}
