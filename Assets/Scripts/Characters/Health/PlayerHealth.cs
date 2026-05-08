using UnityEngine;

 class PlayerHealth : Health, IHealable
{
    public void TakeHeal(int healAmount)
    {
        if (healAmount > 0)
        {
            _currentValue += healAmount;
            ClampValue();
        }        
    }
}
