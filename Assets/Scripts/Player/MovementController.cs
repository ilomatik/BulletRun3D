using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class MovementController : MonoBehaviour
    {
        private enum Side
        {
            Left,
            Center,
            Right
        }

        [Header("Components")] 
        [SerializeField] private Transform sideMovementTransform;

        [Header("Variables")]
        [SerializeField] private float defaultForwardSpeed;
        [SerializeField] private float sideMovementDuration;
        
        [Header("Road Specific Variables")] 
        [SerializeField] private Side currentSide;
        [SerializeField] private float sideDistance;

        private float currentSpeed;
        private Vector3 sideMovementTargetLocalPosition;

        public void MoveForwardStart()
        {
            currentSpeed = defaultForwardSpeed;
        }

        public void MoveForwardStop()
        {
            currentSpeed = 0;
        }

        public void SetForwardSpeed(float newSpeed, bool setDefault = false)
        {
            currentSpeed = newSpeed;

            if (setDefault)
            {
                defaultForwardSpeed = newSpeed;
            }
        }

        public void MoveRight()
        {
            if (currentSide == Side.Right) return;

            sideMovementTargetLocalPosition = sideMovementTransform.localPosition;
            sideMovementTargetLocalPosition.x += sideDistance;
            sideMovementTransform.localPosition = sideMovementTargetLocalPosition;
        }

        public void MoveLeft()
        {
            if (currentSide == Side.Left) return;

            sideMovementTargetLocalPosition = sideMovementTransform.localPosition;
            sideMovementTargetLocalPosition.x -= sideDistance;
            sideMovementTransform.localPosition = sideMovementTargetLocalPosition;
        }
    }
}
