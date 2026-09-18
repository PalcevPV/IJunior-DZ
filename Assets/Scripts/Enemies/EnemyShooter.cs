using System.Collections;
using UnityEngine;

public class EnemyShooter : Shooter
{
    [SerializeField] private float _delay = 1f;
    private Coroutine _shootCoroutine;

    private void OnDisable()
    {
        if (_shootCoroutine != null)
            StopCoroutine(_shootCoroutine);
    }

    public void SetBulletPool(BulletPool bulletPool)
    {
        _bulletPool = bulletPool;
        _shootCoroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Shoot();

            yield return wait; 
        }
    }
}
