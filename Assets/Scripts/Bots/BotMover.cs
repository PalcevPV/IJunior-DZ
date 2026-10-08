using UnityEngine;

public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _arrivalDistance = 0.1f;

    public void MoveTo(Vector3 target)
    {
        target.y = transform.position.y;

        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    public bool HasArrived(Vector3 target)
    {
        target.y = transform.position.y;

        return (target - transform.position).sqrMagnitude <= _arrivalDistance * _arrivalDistance;
    }
}