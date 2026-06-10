using UnityEngine;

class PlayerHealth : Health
{
    public void TakeHeal(float healAmount)
    {
        if (healAmount > 0)
        {
            ChangeHealth(healAmount);
        }
    }
}
