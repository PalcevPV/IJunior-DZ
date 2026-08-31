using System.Collections;
using UnityEngine;

public class ColumnGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private ColumnPool _pool;

    private void Start()
    {       
        StartCoroutine(GenerateColumns());
    }

    private IEnumerator GenerateColumns()
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
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var column = _pool.Spawn(spawnPoint);
    }
}
