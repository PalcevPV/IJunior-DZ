using System;
using UnityEngine;

[RequireComponent(typeof(AirplaneMover), typeof(ScoreCounter), typeof(PlaneCollisionHandler))]
[RequireComponent(typeof(InputHandler), typeof(PlayerShooter))]
public class Airplane : MonoBehaviour
{
    private AirplaneMover _airplaneMover;
    private ScoreCounter _scoreCounter;
    private PlaneCollisionHandler _collisionHandler;
    private InputHandler _inputHandler;
    private PlayerShooter _playerShooter;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
        _collisionHandler = GetComponent<PlaneCollisionHandler>();
        _airplaneMover = GetComponent<AirplaneMover>();
        _inputHandler = GetComponent<InputHandler>();
        _playerShooter = GetComponent<PlayerShooter>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        if (_inputHandler.GetIsJump())
        {
            _airplaneMover.Jump();
        }

        if (_inputHandler.GetIsAttack())
        {
            _playerShooter.Shoot();
        }
    }

    private void ProcessCollision(IInteractable interactable)
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _airplaneMover.Reset();
    }
}