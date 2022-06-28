using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameController gameController;
        [SerializeField] private UIManager uiManager;

        private void Start()
        {
            gameController.GameStart();
        }
    }
}