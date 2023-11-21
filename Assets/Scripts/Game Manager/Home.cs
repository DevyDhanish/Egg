using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : GameStates
{
    public override void onEnter()
    {
        GAME.Instance.gameState = GAME.GameState.HOME;
        GAME.Instance.HomeUI.gameObject.SetActive(true);
    }

    public override void onExit()
    {
        GAME.Instance.HomeUI.gameObject.SetActive(false);
    }

    public override void onUpdate()
    {
        
    }
}
