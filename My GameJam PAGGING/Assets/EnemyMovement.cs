using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float Health;
    public float Speed;
    public float Damage;
    public float IFrames;

    public GameObject Player;

    public PlayerMovement playerMovement;

    public ProjectileMove Projectile;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = Player.GetComponent<PlayerMovement>();
        IFrames = 0.35f;
    }

    void Update()
    {
        if(Health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("EnemyDeath");
            FindObjectOfType<ScoreManager>().ScoreGained();
            Destroy(gameObject);
        }   
    }

    public void FixedUpdate()
    {
        IFrames = IFrames + Time.deltaTime;
        if (Player == null)
        {

        }
        else
        {
            if (Vector2.Distance(transform.position, Player.transform.position) < 10)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Projectile = collision.GetComponent<ProjectileMove>();

        if(collision.tag == "Projectile")
        {
            Health = Health - Projectile.Damage;
            FindObjectOfType<AudioManager>().Play("EnemyHurt");
        }
        else if(collision.tag == "Player" && IFrames > 0.35)
        {
            playerMovement.TakeDamage(Damage, transform.position);
            IFrames = 0;
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }
}
