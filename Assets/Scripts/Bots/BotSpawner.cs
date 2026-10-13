using UnityEngine;

public class BotSpawner : MonoBehaviour
{
    [SerializeField] private Bot _prefab;

    public Bot Spawn(Vector3 position)
    {
        return Instantiate(_prefab, position, Quaternion.identity);
    }
}
