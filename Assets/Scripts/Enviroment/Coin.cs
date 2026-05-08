using System;
using UnityEngine;

public class Coin : Collectible
{
    public event Action<Coin> Collected;

    public override void Pick()
    {
        Collected?.Invoke(this);
    }
}
