using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    public event Action<Enemy> Killed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet) && bullet.Faction == Faction.Player)
        {
            Killed?.Invoke(this);
        }
    }
}