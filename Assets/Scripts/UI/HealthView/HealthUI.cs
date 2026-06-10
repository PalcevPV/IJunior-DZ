using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected int _currentHealth;
    protected int _maxHealth;

    private void OnEnable()
    {
        _health.HealthChanged += UpdateHealthView;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateHealthView;
    }

    protected abstract void UpdateHealthView(int _currentHealth, int _maxHealth);
}