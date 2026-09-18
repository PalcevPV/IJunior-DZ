using System;
using UnityEngine;

public class EnemyPool : Pool<Enemy>
{
    public event Action EnemyKilled;

    public override Enemy Spawn(Vector3 position)
    {
        Enemy enemy = base.Spawn(position);
        enemy.Killed += OnEnemyKilled;

        return enemy;
    }

    public override void Release(Enemy enemy)
    {
        enemy.Killed -= OnEnemyKilled;

        base.Release(enemy);
    }

    private void OnEnemyKilled(Enemy enemy)
    {
        Release(enemy);
        EnemyKilled?.Invoke();
    }
}