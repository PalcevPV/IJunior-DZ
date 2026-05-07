using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private List<SpawnPoint> _allSpawnPoints;
    [SerializeField] private float _spawnDelay = 2f;

    private Dictionary<T,  SpawnPoint> _activeItems;
    private List<SpawnPoint> _freeSpawnPoints;
    private WaitForSeconds _spawnWait;
    private int _poolCapacity = 6;
    private int _poolMaxSize = 8;
    private bool _isActive = true;

    private ObjectPool<T> _pool;

    private void Awake()
    {
        _freeSpawnPoints = new List<SpawnPoint>(_allSpawnPoints);
        _activeItems = new Dictionary<T, SpawnPoint>();

        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (item) => item.gameObject.SetActive(true),
            actionOnRelease: (item) => item.gameObject.SetActive(false),
            actionOnDestroy: (item) => Destroy(item.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _spawnWait = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnLoop());
    }

    protected abstract void Subscribe(T item, SpawnPoint point);

    protected void ReturnToPool(T item)
    {
        if (_activeItems.TryGetValue(item, out var spawnPoint))
        {
            _activeItems.Remove(item);
            _freeSpawnPoints.Add(spawnPoint);
        }

        _pool.Release(item);
    }

    private void Spawn()
    {
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

        if (spawnPoint == null)
        {
            return;
        }

        T item = _pool.Get();

        item.transform.position = spawnPoint.transform.position;

        Subscribe(item, spawnPoint);

        _activeItems[item] = spawnPoint;
        _freeSpawnPoints.Remove(spawnPoint);
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        int minIndex = 0;

        if (_freeSpawnPoints.Count == minIndex)
        {
            return null;
        }

        return _freeSpawnPoints[Random.Range(minIndex, _freeSpawnPoints.Count)]; ;
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