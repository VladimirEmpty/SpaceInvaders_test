using UnityEngine;
using LasyDI;

namespace Code.Unit
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public abstract class GameUnit : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _health;
        private int _currentHealth;

        public BoxCollider2D BoxCollider { get; private set; }
        public Rigidbody2D Rigidbody { get; private set; }
        protected Game Game { get; private set; }
        protected float Speed => _speed;
        protected int Health => _health;

        [Inject]
        public void Construct(Game game)
        {
            Game = game;
            _currentHealth = _health;
        }

        public void Hit(int damage)
        {
            _currentHealth -= damage;

            if(_currentHealth <= 0)
            {
                DestroyUnit();
                _currentHealth = _health;
            }
        }

        protected virtual void DestroyUnit() { }
        protected virtual void TriggerEnter(Collider2D collision) { }

        private void Awake()
        {
            BoxCollider = GetComponent<BoxCollider2D>();
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision) => TriggerEnter(collision);

    }
}

