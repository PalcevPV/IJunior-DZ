using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Coin _coin;

    private void Awake()
    {
        _coin = GetComponent<Coin>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _coin.Pick();
            player.CollectCoin();
        }
    }
}
