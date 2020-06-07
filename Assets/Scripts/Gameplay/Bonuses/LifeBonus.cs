using System;
using Gameplay.Spaceships;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.ShipControllers;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Weapons.Projectiles;
using Gameplay.ShipSystems;

public class LifeBonus : MonoBehaviour
{
    [SerializeField]
    Spaceship Spaceship;

    [SerializeField]
    ShipController ship;

    [SerializeField]
    MovementSystem movementSystem;

    // Start is called before the first frame update
    void Start()
    {
        Spaceship = FindObjectOfType<Spaceship>();
        ship = FindObjectOfType<ShipController>();
        movementSystem = FindObjectOfType<MovementSystem>();
    }
    // Update is called once per frame
    void Update()
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerShipController>();

        if (player == null)
            return;

        Spaceship.Health += 50;

    }
}
