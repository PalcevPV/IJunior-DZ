using UnityEngine;

 class PlayerHealth : Health, IHealable
{
    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
        ClampHealth();
    }
}
