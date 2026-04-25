using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpawnPoint _spawnPoint;
    public event Action<Coin> IsCollected;

    public SpawnPoint SpawnPoint => _spawnPoint;

    public void Initilization(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void Pick()
    {
        IsCollected?.Invoke(this);
    }
}