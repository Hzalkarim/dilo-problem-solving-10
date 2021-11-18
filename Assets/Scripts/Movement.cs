using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Vector3 direction;

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
