using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D rb;
    int dashSpeed = 200000;
    bool dash = true;
    int dashcol = 80;
    private void FixedUpdate()
    {
        if(dashcol == 0)
        {
            dash = true;
        } else
        {
            dashcol--;
        }

        rb.velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.Space) && dash)
        {
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            rb.AddForce(mouseDirection * dashSpeed * Time.fixedDeltaTime);
            dash = false;
            dashcol = 80;
        }
    }
}
