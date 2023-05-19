using System;
using System.Collections.Generic;
using LasyDI;
using UnityEngine;

using Code.Pool;

namespace Code.Unit
{
    public enum BonusType
    {
        DoubleShoot,
        ShootGun
    }

    public sealed class Bonus : GameUnit
    {
        [SerializeField] private List<BonusSetting> _settings;
        private BonusPool _pool;
        private GameObject _view;
        private float _lifeTime;
        private BonusType _bonusType;

        public BonusType BonusType
        {
            get => _bonusType;
            set
            {
                _bonusType = value;
                _view?.SetActive(false);

                _view = _settings.Find(x => x.bonusType == value).bonusView;
                _view.SetActive(true);

                _lifeTime = Time.time + 5f;
            }
        }

        [Inject]
        public void Construct(Game game, BonusPool pool)
        {
            base.Construct(game);
            _pool = pool;
        }

        private void Update()
        {
            Rigidbody.velocity = Vector2.down * Speed;

            if(_lifeTime <= Time.time)
            {
                _pool.Despawn(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _pool.Despawn(this);
        }

        [Serializable]
        private sealed class BonusSetting
        {
            public BonusType bonusType;
            public GameObject bonusView;
        }
    }
}
