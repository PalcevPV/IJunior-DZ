using System.Collections;
using UnityEngine;

public abstract class ObjectGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ColumnPool _pool;

    private void Start()
    {
        StartCoroutine(GenerateObject());
    }

    private IEnumerator GenerateObject()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_lowerBound, _upperBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var sapwnObject = _pool.Spawn(spawnPoint);
    }
}
