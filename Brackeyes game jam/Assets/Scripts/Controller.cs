using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Controller : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
    public string FacingDir = "right";
    SpriteRenderer SpriteRend;

    void Update()
    {
        //Input detection
        Vector2 Userinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        rb.velocity = Userinput * Speed;

        //Detects which direction the player is facing
        if(Userinput.x < 0)
        {
            FacingDir = "left";
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Userinput.x > 0)
        {
            FacingDir = "right";
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Userinput.y < 0)
        {
            FacingDir = "down";
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Userinput.y > 0)
        {
            FacingDir = "up";
            transform.eulerAngles = new Vector3(0, 0, 270);
        }

    }
    

    
}

