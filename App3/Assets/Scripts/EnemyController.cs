using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform player;
    public int moveSpeed;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.rotation = Quaternion.LookRotation(transform.position - player.position);
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }
}
