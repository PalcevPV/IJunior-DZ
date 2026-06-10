using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : HealthUI
{
    [SerializeField] private Slider _slider;

    protected override void UpdateHealthView(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth;
    }
}
