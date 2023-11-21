using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : GameStates
{
    public override void onEnter()
    {
        GAME.Instance.gameState = GAME.GameState.RUNNING;
        GAME.Instance.RunningUI.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void onExit()
    {
        GAME.Instance.RunningUI.gameObject.SetActive(false);
    }

    public override void onUpdate()
    {
        
    }
}