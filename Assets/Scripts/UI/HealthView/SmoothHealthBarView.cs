using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : HealthUI
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    private Coroutine _coroutine;
    private float _targetHealth;

    protected override void UpdateHealthView(float currentHealth, float maxHealth)
    {
        _targetHealth = currentHealth / maxHealth;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(AnimateHealthIndicator());
    }

    private IEnumerator AnimateHealthIndicator()
    {
        while (_slider.value != _targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetHealth, _speed * Time.deltaTime);

            yield return null;
        }
    }
}