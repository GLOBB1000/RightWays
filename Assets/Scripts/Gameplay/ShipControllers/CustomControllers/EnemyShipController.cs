using System.Collections;
using System.Collections.Generic;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    [SerializeField]
    private bool LeftRightMovement;

    private bool _fire = true;
    
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        if(LeftRightMovement == false)
        movementSystem.LongitudinalMovement(Time.deltaTime);

        movementSystem.LateralMovement(Time.deltaTime);
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }


    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }
}
