using UnityEngine;

namespace Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        [SerializeField] private FireController fireController;
        [SerializeField] private PowerController powerController;

        public void ControlActivate()
        {
            InputHandler.OnSelect += movementController.MoveForwardStart;
            InputHandler.OnRelease += movementController.MoveForwardStop;
            InputHandler.OnSwipeLeft += movementController.MoveLeft;
            InputHandler.OnSwipeRight += movementController.MoveRight;
        }

        public void ControlDeActivate()
        {
            InputHandler.OnSelect -= movementController.MoveForwardStart;
            InputHandler.OnRelease -= movementController.MoveForwardStop;
            InputHandler.OnSwipeLeft -= movementController.MoveLeft;
            InputHandler.OnSwipeRight -= movementController.MoveRight;
        }

        public void StopMovementDirectly()
        {
            movementController.MoveForwardStop();
        }
    }
}