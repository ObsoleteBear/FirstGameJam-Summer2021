using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Rigidbody2D rb2D;
    GameObject Player; 




    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(3, rb2D.velocity.y);
            transform.localScale = new Vector2(1, 1);


        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-3, rb2D.velocity.y);
            transform.localScale = new Vector2(-1, 1);
       
        }
        else { 
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }
       
        
        // transform.

    }
}
