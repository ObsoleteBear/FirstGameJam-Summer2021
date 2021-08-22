using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float Speed;
    public float Damage;

    public Vector2 moveDir;

    public bool setDir = false;

    public Rigidbody2D rb;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.lastDir != Vector2.zero && setDir == false)
        {
            moveDir = new Vector2(playerMovement.lastDir.x, playerMovement.lastDir.y);
            setDir = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" | collision.tag == "WallCollider")
        {

        }
        else
        {
            Debug.Log(collision.tag);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveDir * Speed;
    }
}
