using System;
using UnityEngine;

abstract class Health : MonoBehaviour
{
    protected int MaxValue = 100;
    protected int MinValue = 0;
    protected int CurrentValue;

    public event Action <int, int> HealthChanged;

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            ChangeHealth(-damage);
        }     
    }

    protected void ChangeHealth(int healthCount)
    {
        CurrentValue += healthCount;
        CurrentValue = Mathf.Clamp(CurrentValue, MinValue, MaxValue);
        HealthChanged?.Invoke(CurrentValue, MaxValue);
    }
}