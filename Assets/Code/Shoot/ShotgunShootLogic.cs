using UnityEngine;

namespace Code.Shoot
{
    public sealed class ShotgunShootLogic : UseBulletPoolShootLogic
    {
        private const int ShootCount = 5;

        public override void ExecuteFire(Vector2 firePoint)
        {
            var currentAngle = 180f;
            var radius = 0.5f;
            var step = currentAngle / ShootCount;
            var position = Vector2.zero;

            for (var i = 0; i <= ShootCount; ++i)
            {
                position.x = firePoint.x + Mathf.Cos(currentAngle * Mathf.Deg2Rad) * radius;
                position.y = firePoint.y + Mathf.Sin(currentAngle * Mathf.Deg2Rad) * radius;

                var bullet = BulletPool.Spawn();
                bullet.transform.position = position;
                bullet.transform.up = position - firePoint;

                currentAngle -= step;
            }
        }
    }
}
