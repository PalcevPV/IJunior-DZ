using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private Animator _animator;
    private float _moveInput;
    private float _speed = 5f;
    private float _jumpForce = 10f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("Horizontal");

        _animator.SetBool("IsMoving", _moveInput != 0 && _groundChecker.IsGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && _groundChecker.IsGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        _rigidbody.linearVelocity = new Vector2(_moveInput * _speed, _rigidbody.linearVelocity.y);

        Flip();
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }

    private void Flip()
    {
        if (_moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}