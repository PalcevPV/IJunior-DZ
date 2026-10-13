using UnityEngine;

[System.Serializable]
public class BotSlot : MonoBehaviour
{
    [SerializeField] private Bot _bot;
    [SerializeField] private Transform _deliveryPoint;

    public Bot Bot => _bot;
    public Transform DeliveryPoint => _deliveryPoint;

    public void Initialize(Bot bot, Transform deliveryPoint)
    {
        _bot = bot;
        _deliveryPoint = deliveryPoint;
    }
}
