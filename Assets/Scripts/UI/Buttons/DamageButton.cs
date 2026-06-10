using UnityEngine;

public class DamageButton : BaseButton
{
    [SerializeField] private PlayerHealth _health;

    public override void OnClick()
    {
        _health.TakeDamage(_healthCount);
    }
}
