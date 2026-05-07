using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;   

    private Vector2 _targetPoint;
    private Vector2 _direction;
    private float _sqrTargetDistance = 0.01f;
    private int _currentWaypoint = 0;

    public Vector2 GetTarget()
    {
        if (_waypoints == null || _waypoints.Count == 0)
            return transform.position;

        _targetPoint = _waypoints[_currentWaypoint].position;
        _direction = _targetPoint - (Vector2)transform.position;

        if (_direction.sqrMagnitude < _sqrTargetDistance)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Count;
        }

        return _waypoints[_currentWaypoint].position;
    }
}
