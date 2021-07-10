using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public BoxCollider2D coll;
    // Start is called before the first frame update
    void Awake()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    public void DisableObject()
    {
        coll.enabled = false;
        Renderer.enabled = false;
    }
}
