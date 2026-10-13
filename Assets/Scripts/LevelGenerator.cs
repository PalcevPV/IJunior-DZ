using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private ResourceGenerator _resourceGenerator;
    [SerializeField] private ResourceData[] _resources;
    [SerializeField] private Bounds _spawnBounds;

    [SerializeField] private float _delay = 5f;

    private void Awake()
    {
        _resourceGenerator.Initialize(_resources);
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        _resourceGenerator.Spawn(GetRandomResource(), GeneratePosition());
    }

    private Vector3 GeneratePosition()
    {
        return new Vector3(Random.Range(_spawnBounds.min.x, _spawnBounds.max.x), _spawnBounds.min.y,
        Random.Range(_spawnBounds.min.z, _spawnBounds.max.z));
    }

    private ResourceType GetRandomResource()
    {
        return _resources[Random.Range(0, _resources.Length)].Type;
    }
}
