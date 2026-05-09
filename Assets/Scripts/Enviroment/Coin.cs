using System;
using UnityEngine;

public class Coin : Item
{
    public event Action<Coin> Collected;

    public override void Pick()
    {
        Collected?.Invoke(this);
    }
}
