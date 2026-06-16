using System;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public int CoinCount { get; private set; } = 0;

    public event Action<int> CoinsCountChanged;

    public void AddCoin()
    {
        CoinCount++;
        CoinsCountChanged?.Invoke(CoinCount);
    }
}
