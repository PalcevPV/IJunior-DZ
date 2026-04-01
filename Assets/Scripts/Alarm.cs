using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    private float _fadeSpeed = 0.5f;
    private float _minVolume = 0.001f;
    private float _maxVolume = 1;
    private float _targetVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            _alarm.volume = _minVolume;
            _targetVolume = _maxVolume;
            _alarm.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Thief thief))
        {
            _alarm.volume = _maxVolume;
            _targetVolume = _minVolume;
        }
    }

    private void Update()
    {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _targetVolume, _fadeSpeed * Time.deltaTime);

        if (_alarm.volume <= _minVolume)
        {
            _alarm.Stop();
        }
    }
}