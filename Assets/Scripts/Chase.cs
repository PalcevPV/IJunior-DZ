using UnityEngine;
public class Chase : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public Vector3 GetTarget()
    {
        return _target.position;
    }
}
