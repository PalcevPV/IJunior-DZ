using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Bullet _bullet;
    private Vector2 _direction;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }    
}
