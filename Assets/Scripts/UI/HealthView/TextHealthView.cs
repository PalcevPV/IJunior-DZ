using TMPro;
using UnityEngine;

public class TextHealthView : HealthUI
{
    [SerializeField] private TextMeshProUGUI _textHealth;

    protected override void UpdateHealthView(float _currentHealth, float _maxHealth)
    {
        _textHealth.text = $"{_currentHealth}/{_maxHealth}";
    }
}
