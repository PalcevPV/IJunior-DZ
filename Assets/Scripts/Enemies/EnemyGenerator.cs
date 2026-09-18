using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private EnemyPool _pool;
    [SerializeField] private BulletPool _bulletPool;

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    private IEnumerator GenerateEnemy()
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

        var enemy = _pool.Spawn(spawnPoint);

        SetPool(enemy);
    }

    private void SetPool(Enemy enemy)
    {
        EnemyShooter shooter = enemy.GetComponent<EnemyShooter>();
        shooter.SetBulletPool(_bulletPool);
    }
}
