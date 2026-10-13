using UnityEngine;

public class BaseFabrica : MonoBehaviour
{
    [SerializeField] private Base _prefab;

    public Base Create(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity);
    }
}
