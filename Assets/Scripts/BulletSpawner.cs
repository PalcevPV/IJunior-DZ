using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _timeWaitShooting = 2f;
    private WaitForSeconds _shootWait;

    private void Start()
    {
        _shootWait = new WaitForSeconds(_timeWaitShooting);
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWork = true;

        while (isWork)
        {
            if (_target != null)
            {
                Vector3 direction = (_target.position - transform.position).normalized;
                Rigidbody bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                bullet.transform.up = direction;
                bullet.linearVelocity = direction * _speed;

                yield return _shootWait;
            }
        }
    }
}