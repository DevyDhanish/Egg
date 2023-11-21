using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MovementState
{
    public abstract void onEnter(MovementController controller);
    public abstract void onUpdate(MovementController controller);
    public abstract void onExit(MovementController controller);
}
