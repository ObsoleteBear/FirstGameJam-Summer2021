using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    private void Start()
    {
        transform.position = points[startingPoint].position;

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {

        }
    }
}
