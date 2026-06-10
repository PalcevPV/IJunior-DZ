using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : HealthUI
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed = 5;
    private float _targetHealth;

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetHealth, _speed * Time.deltaTime);
    }

    protected override void UpdateHealthView(float currentHealth, float maxHealth)
    {
        _targetHealth = currentHealth;
    }
}