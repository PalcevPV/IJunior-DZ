using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private WaitForSeconds _spawnWait;
    private int _poolCapacity = 6;
    private int _poolMaxSize = 8;
    private float _spawnDelay = 2f;
    private bool _isActive = true;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (coin) => coin.gameObject.SetActive(true),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            actionOnDestroy: (coin) => Destroy(coin.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _spawnWait = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnLoop());
    }

    private void Spawn()
    {
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

        if (spawnPoint.IsBusy == false)
        {
            Coin coin = _pool.Get();

            coin.transform.position = spawnPoint.transform.position;
            coin.Initilization(spawnPoint);
            coin.IsCollected += ReturnCoin;

            spawnPoint.IsBusy = true;
        }
    }

    private void ReturnCoin(Coin coin)
    {
        coin.SpawnPoint.IsBusy = false;
        coin.IsCollected -= ReturnCoin;
        _pool.Release(coin);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {     
        int minIndex = 0;

        return _spawnPoints[Random.Range(minIndex, _spawnPoints.Count)];
    }

    private IEnumerator SpawnLoop()
    {
        while (_isActive)
        {
            yield return _spawnWait;
            Spawn();
        }
    }
}