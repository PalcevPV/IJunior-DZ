using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] public Enemy _prefab;
    [SerializeField] private Target _target;
    [SerializeField] private Vector3 _position;

    public Enemy Spawn()
    {
        Enemy enemy = Instantiate(_prefab, _position, transform.rotation);
        enemy.Initialize(_target);

        return enemy;
    }
}