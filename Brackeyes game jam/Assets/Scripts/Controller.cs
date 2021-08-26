using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float Speed = 5f;
    public Rigidbody2D rb;
    [HideInInspector] public bool isFacingRight = true;
    public bool movementEnabled = true;
    void Update()
    {
        if (movementEnabled == true)
        {
            Vector2 UserInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            rb.velocity = UserInput * Speed;
        }
    }
}

