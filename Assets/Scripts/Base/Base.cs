using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BotPlacementGrid), typeof(BotSpawner))]
[RequireComponent(typeof(BotSlotFactory), typeof(Storage), typeof(Flag))]
public class Base : MonoBehaviour
{
    [SerializeField] private List<BotSlot> _botSlots;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private BaseSelection _baseSelection;
    [SerializeField] private ResourceRegistry _resourceRegistry;
    [SerializeField] private BaseFabrica _fabrica;

    private BotPlacementGrid _botPlacementGrid;
    private BotSpawner _botSpawner;
    private BotSlotFactory _botSlotFactory;
    private Storage _storage;
    private BaseFlag _flag;
    private BotSlot _builderSlot;
    private int _resourceCountToAddBot = 3;
    private int _resourceCountToCreateBase = 5;
    private bool _isConstructionInProgress;

    public event Action<Resource> ResourceReceived;

    private void Awake()
    {
        _botPlacementGrid = GetComponent<BotPlacementGrid>();
        _botSpawner = GetComponent<BotSpawner>();
        _botSlotFactory = GetComponent<BotSlotFactory>();
        _storage = GetComponent<Storage>();
        _flag = GetComponent<BaseFlag>();
    }

    private void Start()
    {
        StartCoroutine(Coroutine());
    }

    private void OnEnable()
    {
        foreach (BotSlot slot in _botSlots)
        {
            slot.Bot.ResourceDelivered += ReceiveResource;
            slot.Bot.ArrivedToFlag += BuidNewBase;
        }
    }

    private void OnDisable()
    {
        foreach (BotSlot slot in _botSlots)
        {
            slot.Bot.ResourceDelivered -= ReceiveResource;
            slot.Bot.ArrivedToFlag -= BuidNewBase;
        }
    }

    private void Initialize(ResourceRegistry resourceRegistry, BaseFabrica fabrica)
    {
        _resourceRegistry = resourceRegistry;
        _fabrica = fabrica;
    }

    private void AssignResources()
    {
        if (GetFreeBotSlot(out BotSlot slot) && _resourceRegistry.TryGetFreeResource(out Resource resource))
        {
            slot.Bot.Collect(resource, slot.DeliveryPoint);
        }
    }

    private void SendBotToFlag()
    {
        if (_isConstructionInProgress || HasBotsNotEnaugh())
        {
            return;
        }

        if (GetFreeBotSlot(out BotSlot slot))
        {
            _builderSlot = slot;
            _isConstructionInProgress = true;
            _storage.Spend(_resourceCountToCreateBase);
            slot.Bot.MoveToFlag(_flag.Position);
        }
    }

    private void BuidNewBase(Bot bot)
    {
        Base newBase = _fabrica.Create(_flag.Position.position);

        _flag.Remove();
        newBase.Initialize(_resourceRegistry, _fabrica);
        newBase.TryAddBot(bot);
        _isConstructionInProgress = false;

        bot.ResourceDelivered -= ReceiveResource;
        bot.ArrivedToFlag -= BuidNewBase;
        bot.Restart();
        _botSlots.Remove(_builderSlot);
    }

    private bool GetFreeBotSlot(out BotSlot botSlot)
    {
        foreach (BotSlot slot in _botSlots)
        {
            if (slot.Bot.IsBusy == false)
            {
                botSlot = slot;
                return true;
            }
        }

        botSlot = null;
        return false;
    }

    private void ReceiveResource(Resource resource)
    {
        _storage.AddResource(resource);
        _resourceRegistry.RemoveResource(resource);

        ResourceReceived?.Invoke(resource);

        if (_flag.IsPlaced == false)
        {
            if (HasEnoughResources(_resourceCountToAddBot))
            {
                TryAddBot();
            }
        }
        else
        {
            if (HasBotsNotEnaugh() && HasEnoughResources(_resourceCountToAddBot))
            {
                TryAddBot();
            }
        }
    }

    private IEnumerator Coroutine()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _resourceRegistry.Scan();

            if (_flag.IsPlaced && HasEnoughResources(_resourceCountToCreateBase))
            {
                SendBotToFlag();
            }

            AssignResources();
            yield return wait;
        }
    }

    private bool HasEnoughResources(int resourceCount)
    {
        return _storage.HasEnough(resourceCount);
    }

    private void RegisterBot(Bot bot, Vector3 position)
    {
        _botSlots.Add(_botSlotFactory.Create(bot, position, transform));

        bot.ResourceDelivered += ReceiveResource;
        bot.ArrivedToFlag += BuidNewBase;
    }

    private bool TryAddBot()
    {
        if (_botPlacementGrid.TryReserveSlot(out Vector3 position) == false)
        {
            return false;
        }

        Bot bot = _botSpawner.Spawn(position);
        RegisterBot(bot, position);
        _storage.Spend(_resourceCountToAddBot);

        return true;
    }

    private bool TryAddBot(Bot bot)
    {
        if (_botPlacementGrid.TryReserveSlot(out Vector3 position) == false)
        {
            return false;
        }

        RegisterBot(bot, position);
        return true;
    }

    private bool HasBotsNotEnaugh()
    {
        int botsCountForNewBase = 1;

        return _botSlots.Count <= botsCountForNewBase;
    }
}