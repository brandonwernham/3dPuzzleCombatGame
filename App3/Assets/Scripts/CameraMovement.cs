using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform camPos;

    void Update()
    {
        transform.position = camPos.position;
    }
}
