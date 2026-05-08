using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Collectible> TriggerEntered;

    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.TryGetComponent(out Collectible collectible))
        {
            TriggerEntered?.Invoke(collectible);
            Debug.Log(collectible.GetType());
        }
    }
}
