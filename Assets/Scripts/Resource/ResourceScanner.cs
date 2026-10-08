using System.Collections.Generic;
using UnityEngine;

public class ResourceScanner : MonoBehaviour
{
    [SerializeField] private Bounds _scanBounds;
    [SerializeField] private LayerMask _resourceLayerMask;

    public List<Resource> Scan()
    {
        Collider[] foundObjects = Physics.OverlapBox(_scanBounds.center, _scanBounds.extents,
            Quaternion.identity, _resourceLayerMask);

        List<Resource> resources = AddResourceToList(foundObjects);

        return resources;
    }

    private List<Resource> AddResourceToList(Collider[] foundObjects)
    {
        List<Resource> resources = new List<Resource>();

        foreach (Collider foundObject in foundObjects)
        {
            if (foundObject.TryGetComponent(out Resource resource) && resources.Contains(resource) == false)
            {
                resources.Add(resource);
            }
        }

        return resources;
    }
}
