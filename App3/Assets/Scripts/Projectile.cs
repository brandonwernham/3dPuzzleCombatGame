using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
