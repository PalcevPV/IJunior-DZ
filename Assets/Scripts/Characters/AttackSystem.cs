using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _radius = 1;
    [SerializeField] private LayerMask _targetMask;

    private float _attackCooldown = 1.5f;
    private float _lastAttackTime;
    private int _damage = 25;

    public bool TryAttack()
    {
        if (CanAttack())
        {
            _lastAttackTime = Time.time;
            Attack();
            return true;
        }

        return false;
    }

    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_attackPoint.position, _radius, _targetMask);
        HashSet<IDamageable> damaged = new HashSet<IDamageable>();

        foreach (var hit in hits)
        {
            if (hit.GetComponentInParent<IDamageable>() is IDamageable target)
            {
                if (damaged.Add(target))
                {
                    target.TakeDamage(_damage);
                }
            }
        }
    }

    private bool CanAttack()
    {
        return Time.time >= _lastAttackTime + _attackCooldown;
    }
}
