using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public InputType inputType;

    public Camera mainCamera;

    private Vector3 direction;
    private Vector3 destination;
    private bool startMove = false;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (inputType == InputType.Keyboard)
        {
            MoveInputKeyboard();
        }
        else if (inputType == InputType.Mouse)
        {
            ReadInputMouse();
            MoveToDestination();
        }
    }

    private void ReadInputMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clickPos = mainCamera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            Debug.Log(clickPos);

            destination = new Vector3(clickPos.x, clickPos.y);
            direction = (destination - transform.position).normalized;

            startMove = true;
        }
    }

    private void MoveToDestination()
    {
        if (startMove)
        {
            rb.velocity = direction.normalized * speed * Time.fixedDeltaTime;

            float remainingDist = Vector3.Distance(destination, transform.position);
            if (remainingDist <= .1f)
            {
                startMove = false;
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void MoveInputKeyboard()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        var dir = new Vector2(h, v);
        rb.velocity = dir.normalized * speed * Time.fixedDeltaTime;
    }
}

public enum InputType { Mouse, Keyboard }
