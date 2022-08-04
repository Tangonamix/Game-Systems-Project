using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VelocityMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5;
    void Start()
    {
        rb = GetComponent < Rigidbody>();
    }
    void Update()
    {
        rb.velocity = Vector3.forward * speed;
    }
}
