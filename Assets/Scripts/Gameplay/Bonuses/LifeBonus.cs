using System;
using Gameplay.Spaceships;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.ShipControllers;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Weapons.Projectiles;
using Gameplay.ShipSystems;

//скрипт, который отвечает за движение и уничтожение бонуса жизни
public class LifeBonus : MonoBehaviour
{
    [SerializeField]
    Spaceship spaceship;

    [SerializeField]
    ShipController ship;

    public GameObject[] player;

    [SerializeField]
    MovementSystem movementSystem;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        movementSystem.LongitudinalMovement(Time.deltaTime);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerShipController>();

        if (player != null)
        {
            Destroy(gameObject, 0.02f);
        }

    }
}
