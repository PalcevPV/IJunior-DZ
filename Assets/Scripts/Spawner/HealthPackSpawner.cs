public class HealthPackSpawner : BaseSpawner<HealthPack>
{
    protected override void Subscribe(HealthPack healthPack, SpawnPoint point)
    {
        healthPack.Collected -= ReturnHealthPack;
        healthPack.Collected += ReturnHealthPack;
    }

    private void ReturnHealthPack(HealthPack healthPack)
    {
        healthPack.Collected -= ReturnHealthPack;
        ReturnToPool(healthPack);
    }
}