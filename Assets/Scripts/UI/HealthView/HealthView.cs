using UnityEngine;

public  class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private SmoothBarView _bar;

    private void Start()
    {
        _bar.UpdateView(_health.CurrentValue/_health.MaxValue);
    }

    private void OnEnable()
    {
        _health.AmountChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float currentValue, float maxValue)
    {
        _bar.UpdateView(currentValue / maxValue);
    }
}