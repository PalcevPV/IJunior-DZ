using UnityEngine;

public class HealthPackCollector : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthPack healthPack))
        {
            if (healthPack.TryPick())
            {
                _playerHealth.Heal(healthPack.HealAmount);
            }
        }
    }
}
