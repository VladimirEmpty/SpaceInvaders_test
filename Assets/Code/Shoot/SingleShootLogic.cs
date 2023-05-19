using UnityEngine;

using Code.Pool;

namespace Code.Shoot
{
    public sealed class SingleShootLogic : UseBulletPoolShootLogic
    {
        public override void ExecuteFire(Vector2 firePoint)
        {
            BulletPool.Spawn().transform.position = firePoint;
        }
    }
}
