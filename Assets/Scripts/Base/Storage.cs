using System;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private const int InitialResourceCount = 0;

    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>()
    {
        { ResourceType.Wood, InitialResourceCount },
        { ResourceType.Stone, InitialResourceCount },
        { ResourceType.Gold, InitialResourceCount }
    };

    public void AddResource(Resource resource)
    {
        _resources[resource.Type]++;
    }

    public void Spend(int amount)
    {
        foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
        {
            int spent = Mathf.Min(_resources[type], amount);
            _resources[type] -= spent;
            amount -= spent;

            if (amount == 0)
                break;
        }
    }

    public bool HasEnough(int requiredCount)
    {
        int totalCount = 0;

        foreach (int count in _resources.Values)
        {
            totalCount += count;
        }

        return totalCount >= requiredCount;
    }

}
