using UnityEngine;
using System.Collections.Generic;

public class Mover : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    private float _speed = 10f;
    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_waypoints == null || _waypoints.Count == 0)
            return;

        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.Count;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}