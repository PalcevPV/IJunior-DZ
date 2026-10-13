using UnityEngine;

public class BotSlotFactory : MonoBehaviour
{
    [SerializeField] private BotSlot _prefab;

    public BotSlot Create(Bot bot, Vector3 position, Transform parent)
    {
        BotSlot slot = Instantiate(_prefab, position, Quaternion.identity, parent);

        slot.Initialize(bot, slot.transform);

        return slot;
    }
}