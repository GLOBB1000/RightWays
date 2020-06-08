using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.Spaceships;
using Gameplay.Weapons.Projectiles;
using Gameplay.Weapons;

//Скрипт отвечающий за ракету
public class RocketBeam : Projectile
{
    protected override void Move(float speed)
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }

}
