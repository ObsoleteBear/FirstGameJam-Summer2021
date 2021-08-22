using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(500f, 0f) * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-500f, 0f) * Time.deltaTime);
        }
    }
}
