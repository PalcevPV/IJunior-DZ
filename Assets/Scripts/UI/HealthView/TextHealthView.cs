using TMPro;
using UnityEngine;

public class TextHealthView : HealthUI
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void UpdateHealthView(int _currentHealth,int _maxHealth)
    {
        _healthText.text = $"{_currentHealth}/{_maxHealth}";
    }
}
