using UnityEngine;

public class bulletboi : MonoBehaviour
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
        Destroy(gameObject);
    }
}
