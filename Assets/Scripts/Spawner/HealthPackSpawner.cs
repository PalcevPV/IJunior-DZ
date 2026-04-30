using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class HealthPackSpawner : MonoBehaviour
{
    [SerializeField] private HealthPack _prefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private WaitForSeconds _spawnWait;
    private int _poolCapacity = 6;
    private int _poolMaxSize = 8;
    private float _spawnDelay = 2f;
    private bool _isActive = true;

    private ObjectPool<HealthPack> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<HealthPack>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (healthPack) => ActionOnGet(healthPack),
            actionOnRelease: (healthPack) => healthPack.gameObject.SetActive(false),
            actionOnDestroy: (healthPack) => Destroy(healthPack.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void ActionOnGet(HealthPack healthPack)
    {
        healthPack.gameObject.SetActive(true);
        healthPack.ResetState();
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
            HealthPack healthPack = _pool.Get();

            healthPack.transform.position = spawnPoint.transform.position;
            healthPack.Initilization(spawnPoint);
            healthPack.IsCollected += ReturnCoin;

            spawnPoint.Enable();
        }

        else
        {
            Debug.Log("Busy");
        }
    }

    private void ReturnCoin(HealthPack healthPack)
    {
        healthPack.SpawnPoint.Disable();
        healthPack.IsCollected -= ReturnCoin;
        _pool.Release(healthPack);
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