using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ResourcePool
{
    private Dictionary<ResourceType, ObjectPool<Resource>> _pools = new();

    public ResourcePool(ResourceData[] resourceData)
    {
        foreach (ResourceData data in resourceData)
        {
            _pools.Add(
                data.Type,
                new ObjectPool<Resource>(
                    createFunc: () => Object.Instantiate(data.Prefab),
                    actionOnGet: resource => resource.gameObject.SetActive(true),
                    actionOnRelease: resource => resource.gameObject.SetActive(false),
                    actionOnDestroy: resource => Object.Destroy(resource.gameObject),
                    collectionCheck: true,
                    defaultCapacity: 5,
                    maxSize: 5
                )
            );
        }
    }

    public Resource Get(ResourceType type)
    {
        return _pools[type].Get();
    }

    public void Release(Resource resource)
    {
        _pools[resource.Type].Release(resource);
    }
}