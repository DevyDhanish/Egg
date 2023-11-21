using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkState : MovementState
{
    private Vector3 cameraForward;
    private Vector3 cameraRight;
    private Vector3 relativeDirection;
    public override void onEnter(MovementController controller)
    {
        GAME.Instance.player.currentPlayerState = PLAYER.playerState.WALK;
        //Debug.Log(GAME.Instance.player.currentPlayerState);
    }

    public override void onExit(MovementController controller)
    {
        
    }

    public override void onUpdate(MovementController controller)
    {
        if (!GAME.Instance.player.isGrounded || GAME.Instance.player.isGrappling) return;
        playerWalk(controller);
    }

    private void playerWalk(MovementController controller)
    {
        cameraForward = Camera.main.transform.forward * InputBindings.Instance.movementVector.x;
        cameraRight = Camera.main.transform.right * InputBindings.Instance.movementVector.y;

        relativeDirection = controller.transform.forward.z * cameraForward + controller.transform.right.x * cameraRight;
        
        relativeDirection.y = 0.0f;
        relativeDirection.Normalize();

        controller.playerController.velocity = relativeDirection * GAME.Instance.player.walkSpeed;
    }
}