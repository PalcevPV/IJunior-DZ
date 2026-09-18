using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            _pool.Release(enemy);
        }
    }
}
