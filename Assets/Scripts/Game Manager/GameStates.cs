using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GameStates
{
    public abstract void onEnter();
    public abstract void onUpdate();
    public abstract void onExit();
}
