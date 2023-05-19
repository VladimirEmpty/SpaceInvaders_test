using UnityEngine;
using LasyDI.Pool;

using Code.Unit;

namespace Code.Pool
{
    public sealed class BulletPool : BasePoolObjectDI<Bullet>
    {
        public override void OnSpawn(Bullet currentObject)
        {
            currentObject.gameObject.SetActive(true);
        }

        public override void OnDespawn(Bullet currentObject)
        {
            currentObject.transform.eulerAngles = Vector3.zero;
            currentObject.Rigidbody.velocity = Vector2.zero;
            currentObject.Rigidbody.angularVelocity = default;
            currentObject.gameObject.SetActive(false);
        }
    }
}
