using UnityEngine;

[RequireComponent(typeof(WallChecker), typeof(Rotater), typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
    private WallChecker _wallChecker;
    private Rigidbody2D _rigidbody;
    private Rotater _rotater;

    private float _speed = 1f;
    private float _jumpForce = 4.5f;

    private void Awake()
    {
        _wallChecker = GetComponent<WallChecker>();
        _rotater = GetComponent<Rotater>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 targetPosition)
    {
        float direction = Mathf.Sign(targetPosition.x - transform.position.x);

        _rotater.Flip(direction);

        _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);

        if (_wallChecker.IsWallAhead(direction))
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }
}