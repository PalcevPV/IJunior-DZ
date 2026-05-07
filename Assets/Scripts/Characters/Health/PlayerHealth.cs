using UnityEngine;

 class PlayerHealth : Health, IHealable
{
    public void Heal(int healAmount)
    {
        if (healAmount > 0)
        {
            _currentHealth += healAmount;
            ClampHealth();
        }        
    }
}
