using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Target _target;

    public void Initialize(Target target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.LookAt(_target.transform);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }
}