using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalMove;
    public float verticalMove;

    public Vector2 Move;

    public Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        Move = new Vector2(horizontalMove, verticalMove);

    }

    private void FixedUpdate()
    {
        rb.AddForce(Move * moveSpeed, ForceMode2D.Force);
    }
}
