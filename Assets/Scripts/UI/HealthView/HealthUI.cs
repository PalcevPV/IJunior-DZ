using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void Start()
    {
        UpdateHealthView(_health._currentValue, _health._maxValue);
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