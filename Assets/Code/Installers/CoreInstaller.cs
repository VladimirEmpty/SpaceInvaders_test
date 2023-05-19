using UnityEngine;
using LasyDI;

using Code.Settings;
using Code.Shoot;

namespace Code.Installers
{
    public sealed class CoreInstaller : MonoInstaller
    {
        [SerializeField] private Transform[] _enemyLines;
        [SerializeField] private Transform _rightPoint;
        [SerializeField] private Transform _leftPoint;
        [SerializeField] private Transform _playerPosition;
        [SerializeField] private Transform _deadEndPoint;
        [SerializeField] private GameSettings _gameSettings;

        public override void OnInstall()
        {
            LasyContainer.Bind<Game>()
                .WithParameters(
                        _enemyLines,
                        _leftPoint, 
                        _rightPoint,
                        _playerPosition,
                        _deadEndPoint,
                        _gameSettings)
                .AsSingle();

            LasyContainer.Bind<EnemyService>()
                .AsSingle();

            LasyContainer.Bind<PlayerService>()
                .AsSingle();

            LasyContainer.Bind<BonusService>()
                .WithParameters(_gameSettings)
                .AsSingle();

            LasyContainer.Bind<SingleShootLogic>()
                .AsSingle();

            LasyContainer.Bind<DoubleShootLogic>()
                .AsSingle();

            LasyContainer.Bind<ShotgunShootLogic>()
                .AsSingle();
        }

        private void Reset()
        {
            name = nameof(CoreInstaller);
        }
    }
}
