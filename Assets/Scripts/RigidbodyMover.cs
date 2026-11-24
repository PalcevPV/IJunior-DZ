using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class RigidbodyMover : MonoBehaviour
{
    [SerializeField] private Chase _chase;
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private float _stopDistance = 4f;

    private Rigidbody _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 position = _body.position;
        Vector3 target = _chase.GetTarget();

        Vector3 displacement = CalculateChaseDisplacement(position, target);

        Vector3 velocity = displacement / Time.fixedDeltaTime;
        velocity.y = _body.linearVelocity.y;

        _body.linearVelocity = velocity;
    }

    private Vector3 CalculateChaseDisplacement(Vector3 position, Vector3 targetPosition)
    {
        targetPosition.y = position.y;

        float distance = Vector3.Distance(position, targetPosition);
        float remainingDistance = Mathf.Max(0f, distance - _stopDistance);
        float maxStep = Mathf.Min(_speed * Time.fixedDeltaTime, remainingDistance);

        Vector3 nextPosition = Vector3.MoveTowards(position, targetPosition, maxStep);
        return nextPosition - position;
    }
}