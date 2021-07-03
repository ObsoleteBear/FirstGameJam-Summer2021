using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float Place;
    public Vector2 GoTo;
    public float ProjectileSpeed;
    public GameObject Player;
    public Movement movement;
    public float Health;
    public bool dest;
    private void Start()
    {
         GoTo = new Vector2 (Place, transform.position.y);
        movement = Player.GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GoTo, ProjectileSpeed);
        if (transform.position.x == GoTo.x && dest == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (movement.playerisDead == false)
            {
                //SpawnMore = false;
                //Show game over screen
                movement.Health = movement.Health - 1;
                Destroy(gameObject);
            }
        }
    }
}
