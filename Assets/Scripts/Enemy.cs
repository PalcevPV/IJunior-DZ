using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _direction;
    private float _speed = 10f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
        transform.rotation = Quaternion.LookRotation(_direction);
    }
}
