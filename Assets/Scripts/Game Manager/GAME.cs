using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME : MonoBehaviour
{
    public static GAME Instance;
    public enum GameState
    {
        PAUSED,
        RUNNING,
        SETTINGS,
        HOME,
    }
    public PLAYER player { get; private set; }
    public GameState gameState { get; set; }
    public Canvas HomeUI;
    public Canvas RunningUI;
    public Canvas PausedUI;
    public void initGame()
    {
        player = new PLAYER(200, 4, 7, PLAYER.playerState.IDLE);
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
