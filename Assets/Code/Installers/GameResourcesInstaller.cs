using System;
using UnityEngine;
using LasyDI;

using Code.Unit;
using Code.Pool;
using Code.Shoot;

namespace Code.Installers
{
    public sealed class GameResourcesInstaller : MonoInstaller
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private Bonus _bonusPrefab;

        public override void OnInstall()
        {
            LasyContainer.Bind<Player>()
                .FromPrefab(_playerPrefab)
                .WhereAbstraction<IShootLogic>()
                .FromContainer<SingleShootLogic>()
                .AsSingle();

            LasyContainer.BindPool<BulletPool, Bullet>()
                .FromPrefab(_bulletPrefab);

            LasyContainer.BindPool<EnemyPool, Enemy>()
                .FromPrefab(_enemyPrefab);

            LasyContainer.BindPool<BonusPool, Bonus>()
                .FromPrefab(_bonusPrefab);
        }

        private void Reset()
        {
            name = nameof(GameResourcesInstaller);
        }
    }
}
