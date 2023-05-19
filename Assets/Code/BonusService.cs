using UnityEngine;

using Code.Unit;
using Code.Pool;
using Code.Settings;

namespace Code
{
    public sealed class BonusService
    {
        private readonly GameSettings GameSettings;
        private readonly BonusPool Pool;

        public BonusService(
            GameSettings gameSettings,
            BonusPool bonusPool)
        {
            GameSettings = gameSettings;
            Pool = bonusPool;
        }

        public void CreateBonus(Vector3 position)
        {
            if(Random.value < GameSettings.EnemyDropBonus)
            {
                var bonus = Pool.Spawn();
                bonus.transform.position = position;
                bonus.BonusType = (BonusType)Random.Range(default, (int)BonusType.ShootGun + 1);

            }
        }
    }
}
