using UnityEngine;

public class BulletPool : Pool<Bullet>
{
    public Bullet Spawn(Vector3 position, Faction faction)
    {
        Bullet bullet = base.Spawn(position);
        bullet.SetFaction(faction);

        bullet.OutOfBounds += Release;

        return bullet;
    }

    public override void Release(Bullet bullet)
    {
        bullet.OutOfBounds -= Release;

        base.Release(bullet);
    }
}
