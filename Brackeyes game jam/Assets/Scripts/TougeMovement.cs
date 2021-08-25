using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TougeMovement : MonoBehaviour
{
   
    public float arrowSpeed = 15f;
    public Rigidbody2D rb;
    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * arrowSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bunny")
        {
            Destroy(gameObject);
        }
    }
}
