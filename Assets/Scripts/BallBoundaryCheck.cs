using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBoundaryCheck : MonoBehaviour
{
    // Define the boundary limits
    public float xMin = -10f;
    public float xMax = 10f;
    public float yMin = -5f;
    public float yMax = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get the current position of the object
        Vector2 currentPosition = rb.position;

        // Check if the position is out of bounds and adjust velocity accordingly
        if (currentPosition.x < xMin)
        {
            rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), rb.velocity.y);
            currentPosition.x = xMin;
        }
        else if (currentPosition.x > xMax)
        {
            rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), rb.velocity.y);
            currentPosition.x = xMax;
        }

        if (currentPosition.y < yMin)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y));
            currentPosition.y = yMin;
        }
        else if (currentPosition.y > yMax)
        {
            rb.velocity = new Vector2(rb.velocity.x, -Mathf.Abs(rb.velocity.y));
            currentPosition.y = yMax;
        }

        // Apply the position adjustment
        rb.position = currentPosition;
    }
}