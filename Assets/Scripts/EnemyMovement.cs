using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Transform> _waypoints;
    private float _speed = 1f;
    private int _currentWaypoint = 0;

    private void Update()
    {
        if (_waypoints == null || _waypoints.Count == 0)
            return;

        if (Vector2.Distance(transform.position, _waypoints[_currentWaypoint].position) < 0.1f)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Count;
            Flip(_waypoints[_currentWaypoint].position);
        }

        transform.position = Vector2.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
    private void Flip(Vector2 target)
    {
        if (_waypoints[_currentWaypoint].position.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}