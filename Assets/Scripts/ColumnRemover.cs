using UnityEngine;

public class ColumnRemover : MonoBehaviour
{
    [SerializeField] private ColumnPool _pool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Column column))
        {
            _pool.Release(column);
        }
    }
}
