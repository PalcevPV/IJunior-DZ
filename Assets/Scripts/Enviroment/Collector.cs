using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Item> TriggerEntered;

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.TryGetComponent(out Item collectible))
        {
            TriggerEntered?.Invoke(collectible);
        }
    }
}
