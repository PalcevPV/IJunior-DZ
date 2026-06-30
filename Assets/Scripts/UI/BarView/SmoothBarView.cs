using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    private Coroutine _coroutine;
    private float _targetValue;

    public void UpdateView(float value)
    {
        _targetValue = value;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(AnimateIndicator());
    }

    private IEnumerator AnimateIndicator()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _speed * Time.deltaTime);

            yield return null;
        }
    }
}