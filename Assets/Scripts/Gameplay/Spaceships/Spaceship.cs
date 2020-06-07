using System;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Weapons.Projectiles;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable
    {
        //Объявляю событие, которое будем использовать для подсчета очков и создания бонусов 
        public static event Action OnKilled;


        public LaserBeam laserBeam;
        public RocketBeam rocketBeam;

        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        //Прочность корабля
        public float Health;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;

        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            //Здесь проверяем, если строго больше нуля снимаем Damage
            if (Health > 0)
            {
                Health -= damageDealer.Damage;
            }
            //Если строго равен нулю, то уничтожаем наш корабль или вражеский корабль
            if (Health <= 0)
            {
                Destroy(gameObject);
                if (_battleIdentity == UnitBattleIdentity.Enemy)
                {
                    //Когда погибает враг вызывается событие, вместе с ним вызываются метода для подсчета и создания бонусов
                    OnKilled.Invoke();
                }
            }

        }

    }
}
