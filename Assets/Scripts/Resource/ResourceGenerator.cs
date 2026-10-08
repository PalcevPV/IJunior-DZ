using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    [SerializeField] private Base _base; 
    private ResourcePool _pool;

    private void OnEnable()
    {
        _base.ResourceReceived += OnResourceReceived;
    }

    private void OnDisable()
    {
        _base.ResourceReceived -= OnResourceReceived;
    }

    private void OnResourceReceived(Resource resource)
    {
        _pool.Release(resource);
    }

    public Resource Spawn(ResourceType type, Vector3 position)
    {
        Resource resource = _pool.Get(type);

        resource.transform.position = position;

        return resource;
    }

    public void Initialize(ResourceData[] resources)
    {
        _pool = new ResourcePool(resources);
    }
}
