using UnityEngine;

public class WallChecker : MonoBehaviour
{
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallDistance = 0.5f;
    [SerializeField] private LayerMask _groundMask;

    public bool IsWallAhead(float direction)
    {
        return Physics2D.Raycast(_wallCheck.position, Vector2.right * direction, _wallDistance, _groundMask);
    }
}
