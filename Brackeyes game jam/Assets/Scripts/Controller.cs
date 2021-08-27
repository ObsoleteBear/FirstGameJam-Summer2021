using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float MoveSpeed = 7f;
    public Rigidbody2D rb;
    [HideInInspector] public bool isFacingRight = true;
    public bool movementEnabled = true;
    public bool isEnemy;
    public float aiRange;
    public GameObject Player;
    private Vector2 movement;
    void Update()
    {
        if (movementEnabled == true && isEnemy == false)
        {
            Vector2 UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            rb.velocity = UserInput * MoveSpeed;
        }
        if (isEnemy == true)
        {
            if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) < aiRange)
            {
                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) > 2)
                {
                    Vector3 direction = Player.transform.position - transform.position;
                    direction.Normalize();
                    movement = direction;
                }else
                {
                    movement = Vector2.zero;
                }
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isEnemy == true)
        {
            rb.MovePosition((Vector2)transform.position + (movement * MoveSpeed * Time.deltaTime));
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap" && collision.GetComponent<TrapAttack>().TrapSprung == false)
        {
            MoveSpeed = 1.5f;
            Debug.Log("Amogus");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            MoveSpeed = 7f;
            Debug.Log("Abogus");
        }
    }
}

