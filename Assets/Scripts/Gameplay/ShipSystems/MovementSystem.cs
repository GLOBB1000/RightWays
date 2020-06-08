using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        public float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;

        [SerializeField]
        private float _crossMoving;
    

        public void LateralMovement(float amount)
        {
            Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            Move(amount * _longitudinalMovementSpeed, Vector3.up);
        }

        public void CrossMoving(float amount)
        {
            Move(amount * _crossMoving,  Vector2.left);
        }
        
        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }
    }
}
