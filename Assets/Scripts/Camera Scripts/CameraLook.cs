using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float clampX;
    public float clampY;
    public float sens;
    public float smoothness;

    private float rotY;
    private float rotX;

    void Update()
    {
        if (GAME.Instance.gameState != GAME.GameState.RUNNING) return;

        rotY += InputBindings.Instance.cameraVectorAxis.x * sens;
        rotX += InputBindings.Instance.cameraVectorAxis.y * sens;

        rotX = Mathf.Clamp(rotX, -clampX, clampX);
        //rotY = Mathf.Clamp(rotY, -clampY, clampY);

        Quaternion target = Quaternion.Euler(-rotX, rotY, 0.0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smoothness);
    }
}
