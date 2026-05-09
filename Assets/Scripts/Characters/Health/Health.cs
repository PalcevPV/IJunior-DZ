using UnityEngine;

abstract class Health : MonoBehaviour, IDamageable
{
    protected int MaxValue = 100;
    protected int MinValue = 0;
    protected int CurrentValue;

    private void Awake()
    {
        CurrentValue = MaxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            CurrentValue -= damage;
            ClampValue();
        }     
    }

    protected void ClampValue()
    {
        CurrentValue = Mathf.Clamp(CurrentValue, MinValue, MaxValue);
    }
}
