using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public Transform cam;

    void Update()
    {
        gameObject.transform.rotation = cam.rotation;
    }
}
