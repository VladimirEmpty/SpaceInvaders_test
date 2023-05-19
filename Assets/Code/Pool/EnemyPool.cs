using UnityEngine;
using LasyDI.Pool;

using Code.Unit;

namespace Code.Pool
{
    public sealed class EnemyPool : BasePoolObjectDI<Enemy>
    {
        public override void OnSpawn(Enemy currentObject)
        {
            currentObject.gameObject.SetActive(true);
        }

        public override void OnDespawn(Enemy currentObject)
        {
            currentObject.Rigidbody.velocity = Vector2.zero;
            currentObject.Rigidbody.angularVelocity = default;

            currentObject.gameObject.SetActive(false);
        }
    }
}
