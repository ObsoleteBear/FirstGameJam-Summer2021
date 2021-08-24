using UnityEngine;
using UnityEngine.SceneManagement;
public class ArrowBoi : MonoBehaviour
{
    public float arrowSpeed = 15f;
    public float blue = 1f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * arrowSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "potato")
        {
            SceneManager.LoadScene(3);
        }
    }
}
