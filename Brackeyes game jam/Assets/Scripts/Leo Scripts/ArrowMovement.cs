using UnityEngine;
using UnityEngine.SceneManagement;
public class ArrowMovement : MonoBehaviour
{
    public float arrowSpeed = 15f;
    public float blue = 1f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = gameObject.transform.right * arrowSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" | collision.collider.tag == "PlayerAttack")
        {

        }else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" | collision.tag == "PlayerAttack" | collision.tag == "DoorTrigger")
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
