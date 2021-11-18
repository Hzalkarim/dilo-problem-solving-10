using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;
    public Vector3 direction;

    void Start()
    {
        rb.AddForce(transform.position + (direction * force), ForceMode2D.Impulse);
    }
}
