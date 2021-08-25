using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public float Speed = 5f;
    [HideInInspector] Rigidbody2D rb;
    public float deez_nuts;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 Userinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //transform.Translate(Userinput * Speed * Time.deltaTime);

        rb.velocity = Userinput * Speed;


    }
}

