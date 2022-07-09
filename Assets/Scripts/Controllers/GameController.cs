using Events;
using Player;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance;
        
        [Header("Events")] 
        [SerializeField] private GameEvent onGameStart;
        [SerializeField] private GameEvent onGameEnd;

        public FireController fireController;
        public MovementController movementController;

        private void Awake()
        {
            Instance = this;
        }

        public void GameStart()
        {
            onGameStart.Raise();
        }

        public void GameEnd()
        {
            onGameEnd.Raise();
        }
    }
}