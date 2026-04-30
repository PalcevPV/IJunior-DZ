using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private Transform _target;
    EnemyMover _enemyMover;

    private Vector2 _targetPoint;
    private Vector2 _direction;
    private int _currentWaypoint = 0;

    public Transform Target => _target;

    private void Awake()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void Patrol()
    {
        if (_waypoints == null || _waypoints.Count == 0)
            return;

        _targetPoint = _waypoints[_currentWaypoint].position;
        _direction = _targetPoint - (Vector2)transform.position;

        if (_direction.sqrMagnitude < 0.01f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
        }

        _enemyMover.Move(_waypoints[_currentWaypoint].position);
    }

    public void Chase()
    {
        _enemyMover.Move(_target.position);
    }
}
