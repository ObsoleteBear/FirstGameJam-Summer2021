using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public bool TrapSprung;
    public GameObject CaughtObject;
    public bool startTimer;
    public float trapTimer;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            trapTimer += Time.deltaTime;
            if (trapTimer < 0.01)
            {
                animator.SetBool("TrapSprung", true);
                TrapSprung = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "Player")
        {
            if (CaughtObject == null)
            {
                CaughtObject = collision.gameObject;
                startTimer = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == CaughtObject)
        {
            Destroy(gameObject);
        }
    }
}
