using System;
using UnityEngine;

abstract class Health : MonoBehaviour
{
    private float _maxValue = 100;
    private float _minValue = 0;
    private float _currentValue;

    public event Action<float, float> HealthChanged;

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

    protected void ChangeHealth(float healthCount)
    {
        _currentValue += healthCount;
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
        HealthChanged?.Invoke(_currentValue, _maxValue);
    }
}