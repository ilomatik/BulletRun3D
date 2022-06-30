using Events;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [Header("Events")] 
        [SerializeField] private GameEvent onGameStartButtonClick;
        [SerializeField] private GameEvent onGameStopButtonClick;

        public void GameStopButtonClick()
        {
            onGameStopButtonClick.Raise();
        }

        public void GameStartButtonClick()
        {
            onGameStartButtonClick.Raise();
        }
    }
}