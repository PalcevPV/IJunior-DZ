using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _timeWaitShooting = 2f;

    void Start()
    {
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
                GameObject bullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                if (bullet.TryGetComponent(out Rigidbody bulletRigidbody))
                {
                    bulletRigidbody.transform.up = direction;
                    bulletRigidbody.linearVelocity = direction * _speed;
                }

                yield return new WaitForSeconds(_timeWaitShooting);
            }
        }
    }
}