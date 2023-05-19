using UnityEngine;
using LasyDI;

using Code.Pool;

namespace Code.Shoot
{
    public abstract class UseBulletPoolShootLogic : IShootLogic
    {
        protected BulletPool BulletPool { get; private set; }

        [Inject]
        public void Construct(BulletPool bulletPool)
        {
            BulletPool = bulletPool;
        }

        public abstract void ExecuteFire(Vector2 firePoint);
    }
}
