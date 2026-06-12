using UnityEngine;

public class DamageButton : BaseButton
{
    [SerializeField] private Health _health;
    private int _value = 5;

    public override void OnClick()
    {
        _health.TakeDamage(_value);
    }
}
