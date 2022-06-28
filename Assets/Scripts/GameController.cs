using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private InputHandler inputHandler;
    
    public void GameStart()
    {
        inputHandler.gameObject.SetActive(true);
        player.ControlActivate();
    }

    public void GameEnd()
    {
        player.ControlDeActivate();
        inputHandler.gameObject.SetActive(false);
        player.StopMovementDirectly();
    }
}