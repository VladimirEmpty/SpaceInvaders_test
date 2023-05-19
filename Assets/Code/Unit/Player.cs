using UnityEngine;
using LasyDI;

using Code.Shoot;

namespace Code.Unit
{
    public sealed class Player : GameUnit
    {
        private const string HorisontalAxisName = "Horizontal";

        [SerializeField] private Transform _firePoint;
        private IShootLogic _shootLogic;
        private IShootLogic _bonusShootLogic;

        [Inject]
        public void Construct(Game game, IShootLogic shootLogic)
        {
            base.Construct(game);
            _shootLogic = shootLogic;
        }

        public void ResetPlayer()
        {
            _bonusShootLogic = null;
        }

        private void Update()
        {
            var inputX = Input.GetAxisRaw(HorisontalAxisName);

            Rigidbody.velocity = Vector2.right * inputX * Speed;
            Rigidbody.position = new Vector2(
                                        Mathf.Clamp(Rigidbody.position.x, Game.LeftPoint.position.x, Game.RightPoint.position.x),
                                        Rigidbody.position.y
                                        );

            if (Input.GetMouseButtonDown(0))
            {
                var shootLogic = _bonusShootLogic != null ? _bonusShootLogic : _shootLogic;
                shootLogic.ExecuteFire(_firePoint.position);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Bonus>(out var bonus))
            {
                switch (bonus.BonusType)
                {
                    case BonusType.DoubleShoot:
                        _bonusShootLogic = LasyContainer.GetObject<DoubleShootLogic>();
                        break;
                    case BonusType.ShootGun:
                        _bonusShootLogic = LasyContainer.GetObject<ShotgunShootLogic>();
                        break;
                }
            }
        }
    }
}

