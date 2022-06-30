using System;
using DG.Tweening;
using Power;
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
        
        [Header("Variables")]
        [SerializeField] private float defaultForwardSpeed;
        [SerializeField] private float sideMovementDuration;
        
        [Header("Road Specific Variables")] 
        [SerializeField] private Side currentSide;
        [SerializeField] private float sideDistance;

        private float currentSpeed;
        private bool isSideMoving;
        private bool canMove;
        private Vector2 firstTouchPosition;

        private void Start()
        {
            currentSpeed = defaultForwardSpeed;
        }

        private void Update()
        {
            if (!canMove) return;
            
#if UNITY_EDITOR

            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Moving forward is working");
                MoveForward();
            }
            
            switch (!isSideMoving)
            {
                case true when Input.GetKey(KeyCode.A):
                    MoveLeft();
                    Debug.Log("Moving left is working");
                    break;
                case true when Input.GetKey(KeyCode.D):
                    Debug.Log("Moving right is working");
                    MoveRight();
                    break;
            }
#else

            if (Input.touchCount > 0)
            {
                MoveForward();
                var touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    firstTouchPosition = touch.position;
                }
                else if (isSideMoving && touch.phase == TouchPhase.Moved)
                {
                    if (touch.position.x < firstTouchPosition.x)
                    {
                        MoveLeft();
                    }
                    else
                    if (touch.position.x > firstTouchPosition.x)
                    {
                        MoveRight();
                    }
                }
            }
            
#endif
        }

        public void SetForwardSpeedOnPowerActive(PowerType powerType, float newSpeed)
        {
            if (powerType == PowerType.PlayerSpeed)
            {
                currentSpeed *= newSpeed;
            }
        }

        public void SetForwardSpeedOnPowerDeActive(PowerType powerType, float newSpeed)
        {
            if (powerType == PowerType.PlayerSpeed)
            {
                currentSpeed = defaultForwardSpeed;
            }
        }

        private void MoveForward()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * defaultForwardSpeed);
        }

        private void MoveRight()
        {
            if (currentSide == Side.Right) return;
            if (isSideMoving) return;

            isSideMoving = true;
            transform.DOMoveX(transform.localPosition.x + sideDistance, sideMovementDuration)
                .OnComplete(() => isSideMoving = false);

            currentSide = currentSide switch
            {
                Side.Center => Side.Right,
                Side.Left => Side.Center,
                _ => currentSide
            };
        }

        private void MoveLeft()
        {
            if (currentSide == Side.Left) return;
            if (isSideMoving) return;

            isSideMoving = true;
            transform.DOMoveX(transform.localPosition.x - sideDistance, sideMovementDuration)
                .OnComplete(() => isSideMoving = false);
            
            currentSide = currentSide switch
            {
                Side.Center => Side.Left,
                Side.Right => Side.Center,
                _ => currentSide
            };
        }

        public void CanMove(bool value)
        {
            canMove = value;
        }
    }
}
