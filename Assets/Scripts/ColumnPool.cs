using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ColumnPool : MonoBehaviour
    
{
    [SerializeField] private Column _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;
    private ObjectPool<Column> _pool;
    private HashSet<Column> _activeColumns = new();

    private void Awake()
    {
        _pool = new ObjectPool<Column>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (spawnItem) => spawnItem.gameObject.SetActive(true),
            actionOnRelease: (spawnItem) => spawnItem.gameObject.SetActive(false),
            actionOnDestroy: (spawnItem) => Destroy(spawnItem.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void Release(Column spawnItem)
    {
        _activeColumns.Remove(spawnItem);
        _pool.Release(spawnItem);
    }

    public void ReleaseAll()
    {
        foreach (Column column in _activeColumns)
        {
            _pool.Release(column);
        }

        _activeColumns.Clear();
    }

    public Column Spawn(Vector3 position)
    {
        Column spawnItem = _pool.Get();
        _activeColumns.Add(spawnItem);

        spawnItem.transform.position = position;

        return spawnItem;
    }
}