using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(InputHandler))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _strafeSpeed = 4f;

    private CharacterController _controller;
    private InputHandler _input;
    private float _verticalSpeed = -2f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _input = GetComponent<InputHandler>();
    }

    private void Update()
    {
        Vector2 input = _input.Movement;
        Vector3 velocity = transform.forward * (input.y * _speed) + transform.right * (input.x * _strafeSpeed);

        velocity.y = _verticalSpeed;
        _controller.Move(velocity * Time.deltaTime);
    }
}
