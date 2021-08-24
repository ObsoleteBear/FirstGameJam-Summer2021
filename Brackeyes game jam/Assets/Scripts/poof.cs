using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poof : MonoBehaviour
{
    public float speed;
    private Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("point").GetComponent<Transform>();
    }

    void Update() { 
    
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);

        }
        
    }
    
}
