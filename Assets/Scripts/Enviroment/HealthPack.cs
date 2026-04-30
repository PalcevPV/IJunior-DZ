using System;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private SpawnPoint _spawnPoint;
    private int _healAmount = 15;
    private bool _isPicked = false;

    public event Action<HealthPack> IsCollected;
    public int HealAmount => _healAmount;

    public SpawnPoint SpawnPoint => _spawnPoint;

    public void Initilization(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public bool TryPick()
    {
        if (_isPicked)
        {
            return false;
        }
        else
        {
            _isPicked = true;
            IsCollected?.Invoke(this);

            return true;
        }
    }

    public void ResetState()
    {
        _isPicked = false;
    }
}