using UnityEngine;

public class Player : MonoBehaviour
{
    private int _coinCount = 0;

    public void CollectCoin()
    {
        _coinCount++;
    }
}