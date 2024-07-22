using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceBoundaryCheck : MonoBehaviour
{
    // Define the boundary limits
    public float xMin = -10f;
    public float xMax = 10f;
    public float yMin = -5f;
    public float yMax = 5f;

    void Update()
    {
        // Get the current position of the surface
        Vector3 currentPosition = transform.position;

        // Clamp the position within the boundaries
        currentPosition.x = Mathf.Clamp(currentPosition.x, xMin, xMax);
        currentPosition.y = Mathf.Clamp(currentPosition.y, yMin, yMax);

        // Apply the position adjustment
        transform.position = currentPosition;
    }
}