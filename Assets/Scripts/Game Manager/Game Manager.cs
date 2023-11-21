using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameStates currentState;
    Running runningState = new Running();
    Home home = new Home();
    Paused pauseState = new Paused();

    private void Start()
    {
        GAME.Instance.initGame();
        currentState = home;
        currentState.onEnter();
    }

    private void Update()
    {
        // start game or pause game handler
        if (Input.GetKeyDown(InputBindings.Instance.Interact)) 
        {
            // switch game to running state;
            switchState(runningState);
        }
        else if (Input.GetKeyDown(InputBindings.Instance.PauseGame))
        {
            switchState(pauseState);
        }

        currentState.onUpdate();
    }

    public void switchState(GameStates newState)
    {
        currentState.onExit();
        currentState = newState;
        currentState.onEnter();
    }
}
