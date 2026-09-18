using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;
    private ObjectPool<T> _pool;
    private HashSet<T> _activeObjects = new();

    private void Awake()
    {
        _pool = new ObjectPool<T>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (spawnItem) => spawnItem.gameObject.SetActive(true),
            actionOnRelease: (spawnItem) => spawnItem.gameObject.SetActive(false),
            actionOnDestroy: (spawnItem) => Destroy(spawnItem.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public virtual void Release(T spawnItem)
    {
        _activeObjects.Remove(spawnItem);
        _pool.Release(spawnItem);
    }

    public void ReleaseAll()
    {
        foreach (T spawnItem in new List<T>(_activeObjects))
        {
            Release(spawnItem);
        }
    }

    public virtual T Spawn(Vector3 position)
    {
        T spawnItem = _pool.Get();
        _activeObjects.Add(spawnItem);

        spawnItem.transform.position = position;

        return spawnItem;
    }
}