using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;
    public Transform player;
    public float xRot;
    public float yRot;
    public bool isPaused;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void Update()
    {
        if (!isPaused)
        {
            float xMouse = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * xSensitivity;
            float yMouse = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * ySensitivity;

            yRot += xMouse;
            xRot -= yMouse;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
            player.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}
