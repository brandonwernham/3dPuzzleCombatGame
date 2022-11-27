using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Enemy"))
        {
            int newX = Random.Range(-23, 23);
            int newZ = Random.Range(-23, 23);
            gameObject.transform.position = new Vector3(newX, 1, newZ);
            Debug.Log("coin was re-positioned");
        }

    }
}
