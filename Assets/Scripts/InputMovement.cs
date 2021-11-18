using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var dir = new Vector2(h, v);
        rb.velocity = dir.normalized * speed * Time.fixedDeltaTime;
    }
}
