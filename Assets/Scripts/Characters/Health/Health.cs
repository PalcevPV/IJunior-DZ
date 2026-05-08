using UnityEngine;

abstract class Health : MonoBehaviour, IDamageable
{
    protected int _maxValue = 100;
    protected int _minValue = 0;
    protected int _currentValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentValue -= damage;
            ClampValue();
        }     
    }

    protected void ClampValue()
    {
        _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
    }
}
