using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _targetMask;
    [SerializeField] private float _radius = 1f;

    public float Radius => _radius;

    public IEnumerable<IDamageable> GetTargets()
    {
        Collider2D[] hits = GetHits();
        HashSet<IDamageable> targets = new HashSet<IDamageable>();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable target))
            {
                targets.Add(target);
            }
        }

        return targets;
    }

    public IDamageable GetNearestTarget()
    {
        IDamageable nearestTarget = null;
        float minDistance = float.MaxValue;

        Collider2D[] hits = GetHits();

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out IDamageable target))
            {
                float distanse = (hit.transform.position - transform.position).sqrMagnitude;

                if (distanse < minDistance)
                {
                    minDistance = distanse;
                    nearestTarget = target;
                }
            }
        }

        return nearestTarget;
    }

    private Collider2D[] GetHits()
    {
        return Physics2D.OverlapCircleAll(_attackPoint.position, _radius, _targetMask);
    }
}