using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyAnimator _enemyAnimator;
    private EnemyBehavior _enemyBehavior;
    private AttackSystem _attackSystem;

    private float _distanceToChase = 6f;
    private float _distanceToAttack = 1f;
    private bool _isChase = true;

    private void Awake()
    {
        _enemyBehavior = GetComponent<EnemyBehavior>();
        _attackSystem = GetComponent<AttackSystem>();
        _enemyAnimator = GetComponent<EnemyAnimator>();
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _enemyBehavior.Target.position);

        if (distance < _distanceToChase)
        {
            if (_isChase)
            _enemyBehavior.Chase();

            if (distance < _distanceToAttack)
                _isChase = false;
            else
                _isChase = true;
        }
        else
        {
            _enemyBehavior.Patrol();
        }

        if (distance < _distanceToAttack)
        {
            if(_attackSystem.TryAttack())
                _enemyAnimator.PlayAttack();
        }
    }
}
