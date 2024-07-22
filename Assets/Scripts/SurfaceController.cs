using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceController : MonoBehaviour
{
    public float rotationInterval = 30.0f; // Rotation interval in degrees
    public float rotationSpeed = 360.0f; // Speed of rotation in degrees per second

    private Transform ball;
    private float targetAngle = 0.0f;
    private bool isRotating = false;

    void Start()
    {
        // Find the ball in the scene
        ball = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check for input
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || (Input.GetKeyDown(KeyCode.A))) && !isRotating)
        {
            RotateLeft();
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D)) && !isRotating)
        {
            RotateRight();
        }

        // Rotate towards the target angle
        if (isRotating)
        {
            float currentAngle = Mathf.MoveTowardsAngle(transform.eulerAngles.z, targetAngle, rotationSpeed * Time.deltaTime);
            transform.RotateAround(ball.position, Vector3.forward, currentAngle - transform.eulerAngles.z);

            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle)) < 0.1f)
            {
                transform.RotateAround(ball.position, Vector3.forward, targetAngle - transform.eulerAngles.z);
                isRotating = false;
            }
        }
    }

    void RotateLeft()
    {
        // Decrease the target angle
        targetAngle -= rotationInterval;
        isRotating = true;
    }

    void RotateRight()
    {
        // Increase the target angle
        targetAngle += rotationInterval;
        isRotating = true;
    }
}
