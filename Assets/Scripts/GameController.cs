using Events;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Events")] 
    [SerializeField] private GameEvent onGameStart;
    [SerializeField] private GameEvent onGameEnd;
    
    public void GameStart()
    {
        onGameStart.Raise();
    }

    public void GameEnd()
    {
        onGameEnd.Raise();
    }
}