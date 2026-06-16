using System;
using UnityEngine;

abstract class Health : MonoBehaviour, IDamageable
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

    protected void ChangeHealth(float healthCount)
    {
        CurrentValue += healthCount;
        CurrentValue = Mathf.Clamp(CurrentValue, MinValue, MaxValue);
        AmountChanged?.Invoke(CurrentValue, MaxValue);
    }
}
