using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private float _speed = 4f;
    private float _jumpForce = 8f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody.linearVelocity = new Vector2(direction * _speed, _rigidbody.linearVelocity.y);
    }

    public void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }      
}