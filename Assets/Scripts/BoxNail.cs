using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxNail : MonoBehaviour
{
    public float speed;
    public float spinSpeed;
    public Rigidbody2D rb;
    public float TimeToLive = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }

    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }
}