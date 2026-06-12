using UnityEngine;

public class HealButton : BaseButton
{
    [SerializeField] private Health _health;
    private int _value = 10;

    public override void OnClick()
    {
        _health.TakeHeal(_value);
    }
}
