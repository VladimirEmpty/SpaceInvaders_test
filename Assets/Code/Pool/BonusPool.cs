using UnityEngine;
using LasyDI.Pool;

using Code.Unit;

namespace Code.Pool
{
    public sealed class BonusPool : BasePoolObjectDI<Bonus>
    {
        public override void OnDespawn(Bonus currentObject)
        {
            currentObject.Rigidbody.velocity = Vector2.zero;
            currentObject.Rigidbody.angularVelocity = default;
            currentObject.gameObject.SetActive(false);
        }

        public override void OnSpawn(Bonus currentObject)
        {
            currentObject.gameObject.SetActive(true);
        }
    }
}
