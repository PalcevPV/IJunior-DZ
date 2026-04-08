using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _houseAlarm;

    private float _fadeSpeed = 0.5f;
    private float _minVolume = 0.001f;
    private float _maxVolume = 1;
    private float _targetVolume;
    private bool _isActive;
    private Coroutine _coroutine;

    public AudioSource HouseAlarm => _houseAlarm;
    public float MinVolume => _minVolume;   

    public void SetMaxVolume()
    {
        _houseAlarm.volume = _minVolume;
        _targetVolume = _maxVolume;

        StartFadeCoroitine();
    }

    public void SetMinVolume()
    {
        _houseAlarm.volume = _maxVolume;
        _targetVolume = _minVolume;

        StartFadeCoroitine();
    }

    private IEnumerator Fade()
    {
        _isActive = true;

        while (_isActive)
        {
            _houseAlarm.volume = Mathf.MoveTowards(_houseAlarm.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

            if (_houseAlarm.volume == _targetVolume)
            {
                _isActive = false;
            }

            yield return null;
        }
    }

    private void StartFadeCoroitine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Fade());
    }
}