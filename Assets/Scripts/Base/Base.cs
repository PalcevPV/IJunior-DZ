using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResourceRegistry))]
public class Base : MonoBehaviour
{
    private const int InitialResourceCount = 0;

    [SerializeField] private List<BotSlot> _botSlots;
    [SerializeField] private float _delay = 1f;
    private ResourceRegistry _resourceRegistry;
    private Dictionary<ResourceType, int> _resources = new Dictionary<ResourceType, int>()
    {
        { ResourceType.Wood, InitialResourceCount },
        { ResourceType.Stone, InitialResourceCount },
        { ResourceType.Gold, InitialResourceCount }
    };

    public event Action<Resource> ResourceReceived;

    private void Awake()
    {
        _resourceRegistry = GetComponent<ResourceRegistry>();
    }

    private void OnEnable()
    {
        foreach (BotSlot slot in _botSlots)
        {
            slot.Bot.ResourceDelivered += ReceiveResource;
        }
    }

    private void OnDisable()
    {
        foreach (BotSlot slot in _botSlots)
        {
            slot.Bot.ResourceDelivered -= ReceiveResource;
        }
    }

    private void AssignResources()
    {
        foreach (BotSlot slot in _botSlots)
        {
            if (slot.Bot.IsBusy)
                continue;

            if (_resourceRegistry.TryGetFreeResource(out Resource resource) == false)
                break;

            slot.Bot.Collect(resource, slot.DeliveryPoint);
        }
    }

    private void ReceiveResource(Resource resource)
    {
        _resources[resource.Type]++;

        _resourceRegistry.RemoveResource(resource);

        ResourceReceived?.Invoke(resource);
    }

    private void Start()
    {
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _resourceRegistry.Scan();
            AssignResources();
            yield return wait;
        }
    }
}