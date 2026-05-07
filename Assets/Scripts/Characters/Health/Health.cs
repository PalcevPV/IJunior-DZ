using UnityEngine;

abstract class Health : MonoBehaviour, IDamageable
{
    protected int _maxHealth = 100;
    protected int _minHealth = 0;
    protected int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            ClampHealth();
        }     
    }

    protected void ClampHealth()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
    }
}
