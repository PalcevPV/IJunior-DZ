using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private TargetFinder _targetFinder;
    private IHealable _owner;
    private Coroutine _coroutine;
    private WaitForSeconds _tickDelay;

    private float _duration = 6f;
    private float _cooldown = 4f;
    private float _tickInterval = 0.1f;
    private int _damagePerTick = 2;
    private int _healPerTick = 2;
    private float _fullProgress = 1;
    private float _elapsedTime;

    public event Action<float> AmountChanged;
    public event Action AbilityActivated;
    public event Action AbilityDeactivated;

    private void Awake()
    {
        _owner = GetComponent<IHealable>();

        _tickDelay = new WaitForSeconds(_tickInterval);
    }

    public void TryActivate()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Activate());
        }
    }

    private IEnumerator Activate()
    {
        AbilityActivated?.Invoke();

        _elapsedTime = 0;

        while (_elapsedTime <= _duration)
        {
            IDamageable target = _targetFinder.GetNearestTarget();

            if (target != null)
            {
                target.TakeDamage(_damagePerTick);

                _owner.TakeHeal(_healPerTick);
            }

            _elapsedTime += _tickInterval;
            AmountChanged?.Invoke(_fullProgress - _elapsedTime / _duration);

            yield return _tickDelay;
        }

        yield return Cooldown();

        _coroutine = null;
    }

    private IEnumerator Cooldown()
    {
        AbilityDeactivated?.Invoke();

        _elapsedTime = 0f;

        while (_elapsedTime < _cooldown)
        {
            _elapsedTime += _tickInterval;
            AmountChanged?.Invoke(_elapsedTime / _cooldown);

            yield return _tickDelay;
        }
    }
}