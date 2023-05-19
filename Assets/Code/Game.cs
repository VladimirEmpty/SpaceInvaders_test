using UnityEngine;
using LasyDI;
using BlackGUI;

using Code.Settings;
using Code.Unit;
using Code.GUI.GameOver;
using Code.GUI.MainGame;

namespace Code
{
    public sealed class Game
    {
        private readonly Transform[] EnemyLines;
        private readonly GameSettings GameSettings;
        private readonly EnemyService EnemyService;

        public Game(
            Transform[] enemyLines,
            Transform leftPoint,
            Transform rightPoint,
            Transform playerStartPoint,
            Transform deadEndPoint,
            GameSettings gameSettings,
            EnemyService enemyService)
        {
            EnemyLines = enemyLines;
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
            PlayerStartPoint = playerStartPoint;
            DeadEndPoint = deadEndPoint;
            GameSettings = gameSettings;
            EnemyService = enemyService;
        }

        public Transform LeftPoint { get; }
        public Transform RightPoint { get; }
        public Transform PlayerStartPoint { get; }
        public Transform DeadEndPoint { get; }
        public float EnemyDownOffset => GameSettings.EnemyDownStepOffset;

        public void CreateGame()
        {
            var usedLineCount = Mathf.Clamp(GameSettings.EnemyLineUsedCount, 1, EnemyLines.Length);
            var movementDirection = 1f;

            for(var i = 0; i < usedLineCount; ++i)
            {
                var createPoint = EnemyLines[i].position;

                for (var j = 0; j < GameSettings.EnemyInLineCount; ++j)
                {
                    EnemyService.CreateEnemy(i, movementDirection).Rigidbody.position = createPoint;
                    createPoint += Vector3.right * GameSettings.EnemyOffset;
                }

                movementDirection *= -1;
            }

            var player = LasyContainer.GetObject<Player>();
            player.Rigidbody.position = PlayerStartPoint.position;
            player.ResetPlayer();

            BlackGUIConnector
                .OpenScreen<GameScreen>()
                .AddController<GameScreenController>();
        }

        public void DestoryGame()
        {
            EnemyService.RemoveAll();
        }

        public void GameOver()
        {
            BlackGUIConnector
                .Close<GameScreen>();

            BlackGUIConnector
                .OpenScreen<GameOverScreen>()
                .AddController<GameOverScreenController>();
        }
    }
}
