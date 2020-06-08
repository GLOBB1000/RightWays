using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gameplay.ShipControllers.CustomControllers;
using Gameplay.Spaceships;

//скрипт, который отвечает за вывод количества убитых вражеских кораблей в UI
public class DamageForShip : MonoBehaviour
{
    [SerializeField] Text Health;
    [SerializeField] Spaceship spaceship;

    private void Start()
    {
        spaceship = FindObjectOfType<Spaceship>();
    }
    // Update is called once per frame
    void Update()
    {
        Health.text = "Health   " + spaceship.Health.ToString();
    }
}
