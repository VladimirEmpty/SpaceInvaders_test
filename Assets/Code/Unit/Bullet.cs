using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using LasyDI;

using Code.Pool;

namespace Code.Unit
{
    public sealed class Bullet : GameUnit
    {
        private BulletPool _pool;
        [SerializeField] private float _lifeTime;
        private float _resetTime;
        
        [Inject]
        public void Construct(Game game, BulletPool bulletPool)
        {
            base.Construct(game);
            _pool = bulletPool;
        }

        protected override void TriggerEnter(Collider2D collision)
        {
            _pool.Despawn(this);
        }

        private void OnEnable()
        {
            _resetTime = Time.time + _lifeTime;
        }

        private void Update()
        {
            Rigidbody.velocity = transform.up * Speed;

            if(_resetTime <= Time.time)
            {
                _pool.Despawn(this);
            }
        }
    }
}
