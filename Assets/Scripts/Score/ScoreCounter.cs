using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    private const string BestScoreKey = "BestScore";

    private int _score;

    public int Score => _score;

    public int BestScore => PlayerPrefs.GetInt(BestScoreKey, 0);

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

    public void SaveBestScore()
    {
        if (_score <= BestScore)
            return;

        PlayerPrefs.SetInt(BestScoreKey, _score);
        PlayerPrefs.Save();
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
