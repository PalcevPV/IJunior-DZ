using UnityEngine;

public class HealButton : BaseButton
{
    [SerializeField] private PlayerHealth _health;
    private int _healCount = 10;

    public override void OnClick()
    {
        _health.TakeHeal(_healCount);
    }
}
