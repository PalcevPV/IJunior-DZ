using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _enemyPool.EnemyKilled += Add;
    }

    private void OnDisable()
    {
        _enemyPool.EnemyKilled -= Add;
    }

    public void Add()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
