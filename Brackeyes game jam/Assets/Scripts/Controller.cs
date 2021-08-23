using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;

    void Update()
    {
        Vector2 Userinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //transform.Translate(Userinput * Speed * Time.deltaTime);

        rb.velocity = Userinput * Speed;
    }
}

