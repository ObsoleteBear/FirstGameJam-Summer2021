using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAttack : MonoBehaviour
{
    public bool TrapSprung;
    public GameObject CaughtObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "Player")
        {
            if (CaughtObject == null)
            {
                CaughtObject = collision.gameObject;
                TrapSprung = true;
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
