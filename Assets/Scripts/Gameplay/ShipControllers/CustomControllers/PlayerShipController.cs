using Gameplay.ShipSystems;
using UnityEngine;
using Gameplay.Weapons.Projectiles;
using Gameplay.Spaceships;
using System.Collections.Generic;
using Gameplay.Weapons;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        Weapon[] weapon;
        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            movementSystem.LateralMovement(Input.GetAxis("Horizontal") * Time.deltaTime);
            
            movementSystem.LateralMovement(Input.GetAxis("Vertical") * Time.deltaTime); 
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                fireSystem.TriggerFire();
            }
        }

        //метод для получения бонусов игроком
        private void OnCollisionEnter2D(Collision2D collision)
        {
            //Вариативной переменной присваиваем коллайдер объекта с нужными нам компонентами
            var Heal = collision.gameObject.GetComponent<LifeBonus>();
            var Speed = collision.gameObject.GetComponent<AttackSpeedBonus>();
        
            //Проверяем, если коллайдер есть,то есть не равен null выполняем соответствующие действия
            if(Heal != null)
            {
                var ship = gameObject.GetComponent<Spaceship>();
                ship.Health += 50;
            }
            if(Speed != null)
            {
                weapon = gameObject.GetComponentsInChildren<Weapon>();
                for (int i = 0; i< weapon.Length; i++)
                {
                    weapon[i]._cooldown -= 0.01f;
                    Debug.Log(weapon[i]._cooldown);
                }

            }
        }
    }
}
