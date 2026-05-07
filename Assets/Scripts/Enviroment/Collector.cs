using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<HealthPack> HealthPackTriggerEntered;
    public event Action<Coin> CoinTriggerEntered;

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.TryGetComponent(out HealthPack healthPack))
        {
            HealthPackTriggerEntered?.Invoke(healthPack);
        }

        if (item.TryGetComponent(out Coin coin))
        {
            CoinTriggerEntered?.Invoke(coin);
        }
    }
}
