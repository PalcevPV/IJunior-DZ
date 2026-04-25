using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> _waypoints;
    private Rotater _rotater;
    private Vector2 _target;
    private Vector2 _direction;
    private float _speed = 1f;
    private int _currentWaypoint = 0;

    private void Awake()
    {
        _rotater = GetComponent<Rotater>();
    }

    private void Update()
    {
        if (_waypoints == null || _waypoints.Count == 0)
            return;

        _target = _waypoints[_currentWaypoint].position;
        _direction = _target - (Vector2)transform.position;

        if (_direction.sqrMagnitude < 0.1f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
            _rotater.Flip(_target.x - transform.position.x);
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}