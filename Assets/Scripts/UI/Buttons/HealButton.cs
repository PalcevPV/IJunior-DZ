using UnityEngine;

public class HealButton : BaseButton
{
    [SerializeField] private PlayerHealth _health;

    public override void OnClick()
    {
        _health.TakeHeal(_healthCount);
    }
}
