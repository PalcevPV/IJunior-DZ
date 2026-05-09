using System;
using UnityEngine;

public class HealthPack : Item
{
    private int _healAmount = 15;

    public event Action<HealthPack> Collected;

    public int HealAmount => _healAmount;

    public override void Pick()
    {
        Collected?.Invoke(this);
    }
}