using System;
using UnityEngine;
using LasyDI;

namespace Code.Unit
{
    public sealed class Enemy : GameUnit
    {
        private EnemyService _enemyService;
        private PlayerService _playerService;
        [SerializeField] private int _score;
        private bool _isFliped;

        public event Action<Enemy> OnMoveComplete;
        public event Action<Enemy> OnDestroy;

        public int LineIndex { get; set; }
        
        [Inject]
        public void Construct(
            Game game, 
            EnemyService enemyService,
            PlayerService playerService)
        {
            base.Construct(game);
            _enemyService = enemyService;
            _playerService = playerService;
        }

        public void MoveDown()
        {
            Rigidbody.position -= Vector2.up * Game.EnemyDownOffset;

            if(Rigidbody.position.y <= Game.DeadEndPoint.position.y)
            {
                Game.GameOver();
            }
        }

        protected override void DestroyUnit()
        {
            _playerService.AddScore(_score);
            OnDestroy?.Invoke(this);

            OnMoveComplete = null;
            OnDestroy = null;

            if(_enemyService.EnemyCount <= 0)
            {
                _playerService.ResetScroe();
                Game.CreateGame();
            }
        }

        protected override void TriggerEnter(Collider2D collision)
        {
            Hit(1);
        }

        private void Update()
        {
            Rigidbody.velocity = Vector2.right * Speed * _enemyService.GetMovementDirection(LineIndex);

            if (_isFliped) return;

            if (Rigidbody.transform.position.x <= Game.LeftPoint.position.x
                | Rigidbody.transform.position.x >= Game.RightPoint.position.x)
            {
                _isFliped = true;
                OnMoveComplete?.Invoke(this);
                Invoke(nameof(FlipedComplete), 0.2f);
            }
        }

        private void FlipedComplete()
        {
            _isFliped = false;
        }
    }
}
