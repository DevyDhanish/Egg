using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputBindings : MonoBehaviour
{
    public static InputBindings Instance;
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

    public Vector2 movementVector;
    public Vector2 cameraVectorAxis;
    public KeyCode Forward = KeyCode.W;
    public KeyCode Backward = KeyCode.S;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public string UpAndDown = "Horizontal";
    public string RightAndLeft = "Vertical";
    public string MouseX = "Mouse X";
    public string MouseY = "Mouse Y";
    public KeyCode Interact = KeyCode.E;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode PauseGame = KeyCode.Escape;
    public KeyCode SprintKey = KeyCode.LeftShift;
    public int Mouse0 = 0;
    public int Mouse1 = 1;
    public bool isHoldingShift;
    public bool isHoldingMouse0;
    public bool isHoldingMouse1;
    public bool PressedMouse0;
    public bool PressedMouse1;

    private void getMovementVector()
    {
        movementVector.x = Input.GetAxisRaw(RightAndLeft);
        movementVector.y = Input.GetAxisRaw(UpAndDown);
        movementVector.Normalize();
    }

    private void getMouseMovementVector()
    {
        cameraVectorAxis.x = Input.GetAxisRaw(MouseX);
        cameraVectorAxis.y = Input.GetAxisRaw(MouseY);
    }

    public void Update()
    {
        if (GAME.Instance.gameState != GAME.GameState.RUNNING) { return; }
        
        getMovementVector();
        getMouseMovementVector();
        isHoldingShift = Input.GetKey(SprintKey);

        isHoldingMouse1 = Input.GetMouseButton(Mouse1);
        isHoldingMouse0 = Input.GetMouseButton(Mouse0);

        PressedMouse0 = Input.GetMouseButtonDown(Mouse0);
        PressedMouse1 = Input.GetMouseButtonDown(Mouse1);

        if (movementVector.x != 0 || movementVector.y != 0)
        {
            GAME.Instance.player.setIsMoving(true);
        }
        else
        {
            GAME.Instance.player.setIsMoving(false);
        }
    }
}
