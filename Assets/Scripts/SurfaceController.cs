using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceController : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public float maxRotationSpeed = 5.0f;
    public float acceleration = 0.1f;

    private Transform ball;
    private Vector3 centerPoint;

    private void Start()
    {
        // Find the ball in the scene
        ball = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate the initial center point of rotation
        centerPoint = transform.position;
    }

    private void Update()
    {
        // Get input for rotation
        float rotationInput = Input.GetAxis("Horizontal");

        // Calculate the new center point based on the ball's position
        centerPoint = ball.position;

        // Rotate the surface around the new center point
        transform.RotateAround(centerPoint, Vector3.forward, rotationInput * rotationSpeed * Time.deltaTime);

        // Gradually increase rotation speed
        if (rotationSpeed < maxRotationSpeed)
        {
            rotationSpeed += acceleration * Time.deltaTime;
        }
    }
}