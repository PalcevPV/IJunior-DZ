using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpawnPoint _spawnPoint;
    public event Action<Coin> OnCollected;

    public SpawnPoint SpawnPoint => _spawnPoint;

    public void Initilization(SpawnPoint spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public void Pick()
    {
        OnCollected?.Invoke(this);
    }
}