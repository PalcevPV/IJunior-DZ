using UnityEngine;

public class DamageButton : BaseButton
{
    [SerializeField] private PlayerHealth _health;
    private int _damageCount = 5;

    public override void OnClick()
    {
        _health.TakeDamage(_damageCount);
    }
}
