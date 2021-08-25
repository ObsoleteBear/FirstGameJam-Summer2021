using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float flameSpeed = 15f;
    public float no;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * flameSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
