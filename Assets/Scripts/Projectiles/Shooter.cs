using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Faction _faction;
    [SerializeField] protected BulletPool _bulletPool;

    public void Shoot()
    {
        Bullet bullet = _bulletPool.Spawn(_firePoint.position, _faction);
        BulletMover bulletMover = bullet.GetComponent<BulletMover>();

        bulletMover.SetDirection(_firePoint.right);
    }
}