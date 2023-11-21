using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PLAYER
{
    public enum playerState
    {
        WALK,
        SPRINT,
        IDLE,
    };

    public float walkSpeed { get; private set; }
    public float sprintSpeed { get; private set; }
    public bool isAlive { get; private set;  }
    public bool isMoving { get; private set; }
    public float health { get; private set; }
    public Vector3 directionFacing { get; private set; }

    public playerState currentPlayerState = playerState.IDLE;

    public bool isGrounded;

    public bool isGrappling;

    /// <summary>
    /// Create a Player object which keep track of 
    /// - health
    /// - walkSpeed
    /// - sprintSpeed
    /// - playerState
    /// </summary>
    /// <param name="_health">Still thinking what should be the total health</param>
    /// <param name="_walkSpeed">Still thinking</param>
    /// <param name="_sprintSpeed">Still thinking</param>
    /// <param name="_playerState">Still thinking</param>
    public PLAYER(float _health, float _walkSpeed, float _sprintSpeed, playerState _playerState)
    {
        walkSpeed = _walkSpeed;
        sprintSpeed = _sprintSpeed;
        isAlive = true;
        currentPlayerState = _playerState;
        health = _health;
        directionFacing = Vector3.forward;
    }

    public void reduceHealth() { }

    public void setIsMoving(bool val)
    {
        isMoving = val;
    }

    public void setDirectionFacing(Vector3 _direction)
    {
        directionFacing = _direction;
        directionFacing.Normalize();
    }
}
