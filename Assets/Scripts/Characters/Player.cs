using System;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimator), typeof(Health), typeof(Bag))]
[RequireComponent(typeof(InputReader), typeof(GroundChecker), typeof(PlayerMover))]
[RequireComponent(typeof(AttackSystem), typeof(Rotater), typeof(Collector))]
public class Player : MonoBehaviour
{
    private PlayerAnimator _animator;
    private Health _health;
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
        _health = GetComponent<Health>();
        _bag = GetComponent<Bag>();
    }

    private void OnEnable()
    {
        _collisionHandler.TriggerEntered += CollectItem;
    }

    private void OnDisable()
    {
        _collisionHandler.TriggerEntered -= CollectItem;
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

        _rotation.Flip(_inputReader.Direction);

        _animator.UpdateMovement(_inputReader.Direction, _groundChecker.IsGrounded);
    }

    private void CollectItem(Item collectible)
    {
        switch (collectible)
        {
            case Coin coin:
                CollectCoin(coin);
                break;

            case HealthPack healthPack:
                CollectHealthPack(healthPack);
                break;
        }
    }

    private void CollectCoin(Coin coin)
    {
        _bag.AddCoin();
        coin.Pick();
    }

    private void CollectHealthPack(HealthPack healthPack)
    {
        _health.TakeHeal(healthPack.HealAmount);
        healthPack.Pick();
    }
}