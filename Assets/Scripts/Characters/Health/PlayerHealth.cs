using UnityEngine;

 class PlayerHealth : Health
{
    public void TakeHeal(int healAmount)
    {
        if (healAmount > 0)
        {
            ChangeHealth(healAmount);
        }        
    }
}
