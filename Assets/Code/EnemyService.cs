using System.Collections.Generic;

using Code.Unit;
using Code.Pool;

namespace Code
{
    public sealed class EnemyService
    {
        private readonly EnemyPool EnemyPool;
        private readonly BonusService BonusService;

        private Dictionary<int, EnemyLineContainer> _enemyTable = new Dictionary<int, EnemyLineContainer>();

        public EnemyService(EnemyPool enemyPool, BonusService bonusService)
        {
            EnemyPool = enemyPool;
            BonusService = bonusService;
        }

        public int EnemyCount { get; private set; }

        public Enemy CreateEnemy(int lineIndex, float movementDirection)
        {
            if(!_enemyTable.TryGetValue(lineIndex, out var container))
            {
                container = new EnemyLineContainer();
                _enemyTable.Add(lineIndex, container);
            }

            var enemy = EnemyPool.Spawn();
            enemy.LineIndex = lineIndex;
            enemy.OnMoveComplete += SwitchDirection;
            enemy.OnDestroy += Remove;

            container.enemies.Add(enemy);
            container.movementDirection = movementDirection;

            EnemyCount++;

            return enemy;
        }

        public float GetMovementDirection (int enemyLineIndex)
        {
            var result = 0f;

            if(_enemyTable.TryGetValue(enemyLineIndex, out var container))
            {
                result = container.movementDirection;
            }

            return result;
        }

        public void RemoveAll()
        {
            foreach(var container in _enemyTable)
            {
                while(container.Value.enemies.Count > 0)
                {
                    container.Value.enemies[default].OnDestroy -= Remove;
                    container.Value.enemies[default].OnMoveComplete -= SwitchDirection;
                    EnemyPool.Despawn(container.Value.enemies[default]);
                    container.Value.enemies.Remove(container.Value.enemies[default]);
                }
            }

            EnemyCount = default;
        }

        private void SwitchDirection(Enemy enemy)
        {
            if(_enemyTable.TryGetValue(enemy.LineIndex, out var container))
            {
                container.movementDirection *= -1;
                container.enemies.ForEach(x =>
                {
                    x.MoveDown();
                });
            }
        }

        private void Remove(Enemy enemy)
        {
            if(_enemyTable.TryGetValue(enemy.LineIndex, out var container))
            {
                container.enemies.Remove(enemy);
                EnemyPool.Despawn(enemy);
                BonusService.CreateBonus(enemy.transform.position);
                EnemyCount--;
            }
        }

        private sealed class EnemyLineContainer
        {
            public List<Enemy> enemies = new List<Enemy>();

            public float movementDirection;
        }
    }
}
