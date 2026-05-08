public class CoinSpawner : BaseSpawner<Coin>
{
    protected override void Subscribe(Coin coin, SpawnPoint point)
    {
        coin.Collected -= ReturnCoin;
        coin.Collected += ReturnCoin;
    }

    private void ReturnCoin(Coin coin)
    {
        coin.Collected -= ReturnCoin;
        ReturnToPool(coin);
    }
}