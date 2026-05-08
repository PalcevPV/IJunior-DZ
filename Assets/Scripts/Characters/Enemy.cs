using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyAnimator _enemyAnimator;
    private EnemyMover _enemyMover;
    private Patrol _patrol;
    private Chase _chase;
    private AttackSystem _attackSystem;

    private float _sqrDistanceToChase = 36f;
    private float _sqrDistanceToAttack = 1f;
    private bool _isChase = true;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
        _patrol = GetComponent<Patrol>();
        _attackSystem = GetComponent<AttackSystem>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
        _chase = GetComponent<Chase>();
    }

    private void Update()
    {
        float sqrDistanceToTarget = ((Vector2)transform.position - (Vector2)_chase.GetTarget()).sqrMagnitude;

        if (sqrDistanceToTarget < _sqrDistanceToChase)
        {
            if (_isChase)
                _enemyMover.Move(_chase.GetTarget());

            _isChase = sqrDistanceToTarget >= _sqrDistanceToAttack;
        }
        else
        {
            _enemyMover.Move(_patrol.GetTarget());
        }

        if (sqrDistanceToTarget < _sqrDistanceToAttack)
        {
            if(_attackSystem.TryAttack())
                _enemyAnimator.PlayAttack();
        }
    }
}
