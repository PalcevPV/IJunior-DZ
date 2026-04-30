using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimator _animator;
    private InputReader _inputReader;
    private GroundChecker _groundChecker;
    private PlayerMover _playerMover;
    private AttackSystem _attackSystem;
    private Rotater _rotation;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _inputReader = GetComponent<InputReader>();
        _groundChecker = GetComponent<GroundChecker>();
        _playerMover = GetComponent<PlayerMover>();
        _rotation = GetComponent<Rotater>();
        _attackSystem = GetComponent<AttackSystem>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundChecker.IsGrounded)
        {
            _playerMover.Jump();
        }

        if (_inputReader.GetIsAttack())
        {
            if(_attackSystem.TryAttack())
                _animator.PlayAttack();
        }
    }

    private void Update()
    {
        _rotation.Flip(_inputReader.Direction);
        _animator.UpdateMovement(_inputReader.Direction, _groundChecker.IsGrounded);
    }
}