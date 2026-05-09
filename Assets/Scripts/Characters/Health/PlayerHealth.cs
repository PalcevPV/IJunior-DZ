using UnityEngine;

 class PlayerHealth : Health, IHealable
{
    public void TakeHeal(int healAmount)
    {
        if (healAmount > 0)
        {
            CurrentValue += healAmount;
            ClampValue();
        }        
    }
}
