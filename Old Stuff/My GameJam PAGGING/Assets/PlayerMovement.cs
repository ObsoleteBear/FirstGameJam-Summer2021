using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float Health;
    public float horizontalMove;
    public float verticalMove;
    public float timer;

    public bool HasMoved = false;

    public GameObject ProjectilePrefab;

    public Vector2 Move;
    public Vector2 lastDir;

    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            FindObjectOfType<DeathManager>().poggers();
            Destroy(gameObject);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        

        Move = new Vector2(horizontalMove * moveSpeed, verticalMove * moveSpeed);

        if(Input.anyKey)
        {

        }
        else
        {
            if (timer >= 0.5f && HasMoved == true)
            {
                Instantiate(ProjectilePrefab, transform.position, quaternion.identity);
                //spawn projectiles here
                timer = 0;
            }
        }

        if (Input.GetAxisRaw("Horizontal") != 0 | Input.GetAxisRaw("Vertical") != 0)
        {
            HasMoved = true;
            lastDir = new Vector2(horizontalMove, verticalMove);
        }

    }

    private void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        rb.velocity = Move;
    }

    public void TakeDamage(float Damage, Vector2 damagePlace)
    {
        Health = Health - Damage;
        transform.position = Vector2.MoveTowards(transform.position, damagePlace, -1f);
    }
}
