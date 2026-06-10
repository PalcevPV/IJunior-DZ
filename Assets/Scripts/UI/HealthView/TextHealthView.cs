using TMPro;
using UnityEngine;

public class TextHealthView : HealthUI
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void UpdateHealthView(float _currentHealth, float _maxHealth)
    {
        _healthText.text = $"{_currentHealth}/{_maxHealth}";
    }
}
