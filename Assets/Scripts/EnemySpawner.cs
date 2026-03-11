using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private List<Vector3> _spawnPoints = new List<Vector3>();

    private Coroutine _coroutine;
    private float _spawnDelay = 2f;
    private bool _isActive = true;

    private void Start()
    {
        _coroutine = StartCoroutine(SpawLoop());
    }

    private void SpawnEnemy()
    {
        int minIndex = 0;
        int randomIndex = Random.Range(minIndex, _spawnPoints.Count);

        Enemy enemy = Instantiate(_prefab, _spawnPoints[randomIndex], Quaternion.identity);
        SetDirection(enemy);
    }

    private void SetDirection(Enemy enemy)
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0;

        enemy.SetDirection(randomDirection);
    }

    private IEnumerator SpawLoop()
    {
        while (_isActive)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnEnemy();
        }
    }
}