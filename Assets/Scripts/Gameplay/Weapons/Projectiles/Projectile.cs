using System;
using Gameplay.Helpers;
using UnityEngine;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Spaceships;

namespace Gameplay.Weapons.Projectiles
{
    public abstract class Projectile : MonoBehaviour, IDamageDealer
    {

        [SerializeField]
        private float _speed;

        [SerializeField] 
        private float _damage;

        [SerializeField] private GameController gameController;

        [SerializeField] private Spaceship spaceship;


        private UnitBattleIdentity _battleIdentity;


        public UnitBattleIdentity BattleIdentity => _battleIdentity;
        public float Damage => _damage;

        private void Start()
        {
            gameController = FindObjectOfType<GameController>();
            spaceship = FindObjectOfType<Spaceship>();
        }

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        

        private void Update()
        {
            Move(_speed);
        }

        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>();

            if (damagableObject != null
                && damagableObject.BattleIdentity != BattleIdentity)
            {
                damagableObject.ApplyDamage(this);
                Destroy(gameObject);
            }

            
        }

        protected abstract void Move(float speed);
    }
}
