using System.Collections;
using System.Collections.Generic;
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
