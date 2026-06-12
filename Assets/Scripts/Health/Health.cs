using System;
using UnityEngine;

 public class Health : MonoBehaviour
{
    private float _minValue = 0;
    public float _maxValue { get; private set; } = 100;
    public float _currentValue { get; private set; }

    public event Action<float, float> AmountChanged;

    public float MaxValue => _maxValue;
    public float CurrentValue => _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            ChangeHealth(-damage);
        }
    }

    public void TakeHeal(float healAmount)
    {
        if (healAmount > 0)
        {
            ChangeHealth(healAmount);
        }
    }

    protected void ChangeHealth(float healthCount)
    {
        _currentValue += healthCount;
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        AmountChanged?.Invoke(_currentValue, _maxValue);
    }
}