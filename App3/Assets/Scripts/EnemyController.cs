using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public int moveSpeed;

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }
}
