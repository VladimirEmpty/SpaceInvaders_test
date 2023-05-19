using UnityEngine;

namespace Code.Shoot
{
    public sealed class DoubleShootLogic : UseBulletPoolShootLogic
    {
        private const float Offset = 0.25f;

        public override void ExecuteFire(Vector2 firePoint)
        {
            BulletPool.Spawn().transform.position = firePoint + Vector2.left * Offset;
            BulletPool.Spawn().transform.position = firePoint + Vector2.right * Offset;
        }
    }
}
