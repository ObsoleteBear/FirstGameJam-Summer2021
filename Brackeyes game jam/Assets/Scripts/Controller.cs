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
    public float speedSave;
    public Vector3 direction;
    public Vector2 UserInput;
    void Update()
    {
        direction = Player.transform.position - transform.position;
        direction.Normalize();
        if (movementEnabled == true && isEnemy == false)
        {
            UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        }
        if (isEnemy == true)
        {
            if (Vector2.Distance((Vector2)transform.position, (Vector2)Player.transform.position) < aiRange)
            {
                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) > 2)
                {
                    movement = direction;
                }else
                {
                    movement = Vector2.zero;
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (isEnemy == true)
        {
            rb.AddForce(movement * MoveSpeed * 4);
        }
        else
        {
            rb.AddForce(UserInput * MoveSpeed * 4);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap" && collision.GetComponent<TrapAttack>().TrapSprung == false)
        {
            speedSave = MoveSpeed;
            MoveSpeed = 1.5f;
            Debug.Log("Amogus");
        }
        if (isEnemy == true && collision.tag == "PlayerGravity")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * 420);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trap")
        {
            MoveSpeed = speedSave;
            Debug.Log("Abogus");
        }
    }
}

