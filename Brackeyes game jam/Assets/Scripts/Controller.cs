using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

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
    public Animator animate;
    public float IdleTimer;
    public SpriteRenderer spriteRend;
    public GameManager GameManage;
    private void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        animate = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        GameManage = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        direction = Player.transform.position - transform.position;
        direction.Normalize();
        UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementEnabled == true && isEnemy == false)
        {
            if (UserInput != Vector2.zero)
            {
                animate.SetBool("Moving", true);
                animate.SetBool("Sit", false);
            }
            else
            {
                animate.SetBool("Moving", false);
            }
            if (UserInput.x < 0)
            {
                spriteRend.flipX = true;
            }
            if (UserInput.x > 0)
            {
                spriteRend.flipX = false;
            }
            if (UserInput == Vector2.zero)
            {
                IdleTimer = IdleTimer + Time.deltaTime;
                if (IdleTimer > 4)
                {
                    animate.SetBool("Sit", true);
                }
            }
            else
            {
                IdleTimer = 0;
            }
        }
        if (isEnemy == true && Player.GetComponent<Controller>().enabled == true)
        {
            if (Vector2.Distance((Vector2)transform.position, (Vector2)Player.transform.position) < aiRange)
            {
                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(Player.transform.position.x, Player.transform.position.y)) > 2)
                {
                    movement = direction;
                    animate.SetBool("Moving", true);

                }
                else
                {
                    movement = Vector2.zero;
                    animate.SetBool("Moving", false);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (isEnemy == true)
        {
            rb.AddForce(movement * MoveSpeed * 6);
            if (Player.transform.position.x < transform.position.x)
            {
                spriteRend.flipX = true;
            }else if (Player.transform.position.x > transform.position.x)
            {
                spriteRend.flipX = false;
            }
        }
        else
        {
            rb.AddForce(UserInput * MoveSpeed * 8);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trap" && collision.GetComponent<TrapAttack>().TrapSprung == false)
        {
            MoveSpeed = 1.5f;
            Debug.Log("Amogus");
        }else
        {
            MoveSpeed = 7;
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
        else if (isEnemy == false && collision.tag == "EnemyGravity")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.transform.position - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            rb.AddForce(dir * 420);
        }
        if (collision.tag == "Explosion")
        {
            if (isEnemy == true)
            {
                EnemyDeath();
                animate.SetBool("Dead", true);
            }
            else
            {
                GameManage.PlayerDeath(gameObject);
                animate.SetBool("Dead", true);
            }
        }
        else if (collision.tag == "PlayerAttack" && isEnemy == true)
        {
            //Enemy Death
            EnemyDeath();
            animate.SetBool("Dead", true);
            Destroy(gameObject);
        }
        else if (collision.tag == "EnemyAttack" && isEnemy == false)
        {
            //Player Death
            GameManage.PlayerDeath(gameObject);
            animate.SetBool("Dead", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trap" && collision.GetComponent<TrapAttack>().CaughtObject == gameObject)
        {
            MoveSpeed = speedSave;
            Debug.Log("Abogus");
        }
    }
    public void EnemyDeath() 
    {
        GameManage.EnemyDeath(gameObject);
    }
}


