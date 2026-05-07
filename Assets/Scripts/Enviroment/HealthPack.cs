using System;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private int _healAmount = 15;

    public event Action<HealthPack> Collected;
    public int HealAmount => _healAmount;

    public void Pick()
    {
        Collected?.Invoke(this);
    }
}