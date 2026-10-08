using UnityEngine;

public class BotRotator : MonoBehaviour
{
    private float _minDirectionSqrMagnitude = 0.0001f;

    public void RotateTo(Vector3 target)
    {
        Vector3 direction = target - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > _minDirectionSqrMagnitude)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}