using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints = new List<SpawnPoint>();
    private WaitForSeconds _spawnWait;

    private float _spawnDelay = 2f;
    private bool _isActive = true;

    private void Start()
    {
        StartCoroutine(SpawLoop());
        _spawnWait = new WaitForSeconds(_spawnDelay);
    }

    private void SpawnEnemy()
    {
        int minIndex = 0;
        int randomIndex = Random.Range(minIndex, _spawnPoints.Count);

        Enemy enemy = _spawnPoints[randomIndex].Spawn();
    }

    private IEnumerator SpawLoop()
    {
        while (_isActive)
        {
            yield return _spawnWait;
            SpawnEnemy();
        }
    }
}