using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject spider;
    public float startTime;
    public float timeBetweenSpawn;

    void Update()
    {
        if (timeBetweenSpawn > 0)
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
        if (timeBetweenSpawn <= 0)
        {
            Instantiate(spider, gameObject.transform);
            timeBetweenSpawn = startTime;
        }
    }
}
