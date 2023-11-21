using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    MovementState currentState;
    SprintState sprint = new SprintState();
    WalkState walk = new WalkState();
    IdleState idle = new IdleState();

    public Rigidbody playerController;


    [SerializeField]
    private float GroundCheckRayLenght = 0.3f;
    private void Start()
    {
        currentState = idle;
        currentState.onEnter(this);

        if(playerController == null)
            playerController = gameObject.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GAME.Instance.player.isGrounded = Physics.Raycast(transform.position, -Vector3.up, GroundCheckRayLenght);
        Debug.Log(GAME.Instance.player.isGrounded);

        if (!GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.IDLE) switchState(idle);
        else if (GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.WALK && !InputBindings.Instance.isHoldingShift) switchState(walk);
        else if(GAME.Instance.player.isMoving && GAME.Instance.player.currentPlayerState != PLAYER.playerState.SPRINT && InputBindings.Instance.isHoldingShift) switchState(sprint);

        // set for sprint too

        currentState.onUpdate(this);
    }

    public void switchState(MovementState newState)
    {
        currentState.onExit(this);
        currentState = newState;
        currentState.onEnter(this);
    }
}
