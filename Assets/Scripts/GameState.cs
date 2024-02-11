using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameStateEnum CurrentGameState;
    public enum GameStateEnum
    { 
        Playing,
        Pause
    };
}
