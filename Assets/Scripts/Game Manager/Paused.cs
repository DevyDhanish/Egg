using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : GameStates
{
    public override void onEnter()
    {
        GAME.Instance.gameState = GAME.GameState.PAUSED;
        GAME.Instance.PausedUI.gameObject.SetActive(true);
    }

    public override void onExit()
    {
        GAME.Instance.PausedUI.gameObject.SetActive(false);
    }

    public override void onUpdate()
    {

    }
}