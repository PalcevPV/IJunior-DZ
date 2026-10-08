using UnityEngine;

[CreateAssetMenu]
public class ResourceData : ScriptableObject
{
    [SerializeField] private ResourceType _type;
    [SerializeField] private Resource _prefab;

    public ResourceType Type => _type;
    public Resource Prefab => _prefab;
}
