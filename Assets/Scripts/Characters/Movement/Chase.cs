using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Chase : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public Vector2 GetTarget()
    {
        return _target.position;
    }
}
