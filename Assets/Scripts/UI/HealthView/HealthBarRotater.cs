using UnityEngine;

public class HealthBarRotater : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
}
