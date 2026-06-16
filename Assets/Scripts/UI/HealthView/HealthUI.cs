using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Start()
    {
        UpdateHealthView(_health.CurrentValue, _health.MaxValue);
    }

    private void OnEnable()
    {
        _health.AmountChanged += UpdateHealthView;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= UpdateHealthView;
    }

    protected abstract void UpdateHealthView(float currentHealth, float maxHealth);
}