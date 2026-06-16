using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable, IHealable
{
    private float MinValue = 0;
    public float MaxValue { get; private set; } = 100;
    public float CurrentValue { get; private set; }

    public event Action<float, float> AmountChanged;

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

    public void TakeHeal(int healAmount)
    {
        if (healAmount > 0)
        {
            ChangeHealth(healAmount);
        }
    }

    protected void ChangeHealth(float healthCount)
    {
        CurrentValue += healthCount;
        CurrentValue = Mathf.Clamp(CurrentValue, MinValue, MaxValue);
        AmountChanged?.Invoke(CurrentValue, MaxValue);
    }
}
