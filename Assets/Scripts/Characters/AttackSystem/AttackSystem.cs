using UnityEngine;

[RequireComponent(typeof(TargetFinder))]
public class AttackSystem : MonoBehaviour
{
    private TargetFinder  _targetFinder;

    private float _attackCooldown = 1f;
    private float _nextAttackTime;
    private int _damage = 25;

    private void Awake()
    {
        _targetFinder = GetComponent<TargetFinder>();
    }

    public bool TryAttack()
    {
        if (Time.time >= _nextAttackTime)
        {
            Attack();
            _nextAttackTime = Time.time + _attackCooldown;

            return true;
        }

        return false;
    }

    private void Attack()
    {
        foreach (IDamageable target in _targetFinder.GetTargets())
        {
            target.TakeDamage(_damage);
        }
    }
}