using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerAnimator _animator;
    private PlayerHealth _health;
    private Bag _bag;
    private InputReader _inputReader;
    private GroundChecker _groundChecker;
    private PlayerMover _playerMover;
    private AttackSystem _attackSystem;
    private Rotater _rotation;
    private Collector _collisionHandler;

    private float _lastDirection;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _inputReader = GetComponent<InputReader>();
        _groundChecker = GetComponent<GroundChecker>();
        _playerMover = GetComponent<PlayerMover>();
        _rotation = GetComponent<Rotater>();
        _attackSystem = GetComponent<AttackSystem>();
        _collisionHandler = GetComponent<Collector>();
        _health = GetComponent<PlayerHealth>();
        _bag = GetComponent<Bag>();
    }

    private void OnEnable()
    {
        _collisionHandler.HealthPackTriggerEntered += CollectHealthPack;
        _collisionHandler.CoinTriggerEntered += CollectCoin;
    }

    private void OnDisable()
    {
        _collisionHandler.HealthPackTriggerEntered -= CollectHealthPack;
        _collisionHandler.CoinTriggerEntered -= CollectCoin;
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
            if (_attackSystem.TryAttack())
                _animator.PlayAttack();
        }
    }

    private void Update()
    {
        float direction = _inputReader.Direction;

        if (direction != _lastDirection)
        {
            _rotation.Flip(_inputReader.Direction);
            _animator.UpdateMovement(_inputReader.Direction, _groundChecker.IsGrounded);

            _lastDirection = direction;
        }
    }

    private void CollectHealthPack(HealthPack healthPack)
    {
        _health.Heal(healthPack.HealAmount);
        healthPack.Pick();
    }

    private void CollectCoin(Coin coin)
    {
        _bag.AddCoin();
        coin.Pick();
    }
}