using System;
using Gameplay.Spaceships;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.ShipControllers;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Weapons.Projectiles;
using Gameplay.ShipSystems;
using System.Collections.Generic;

//скрипт, который отвечает за движение и уничтожение бонуса к скорости атаки
public class AttackSpeedBonus : MonoBehaviour
{
    [SerializeField]
    PlayerShipController player;

    [SerializeField]
    MovementSystem movementSystem;

    // Update is called once per frame
    void Update()
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var players = collision.gameObject.GetComponent<PlayerShipController>();

        if (players != null)
        Destroy(gameObject);
    }
}
