using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public float BombTimer;
    public GameObject Explosion;
    public Animator anim;
    void Start()
    {
        BombTimer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        BombTimer = BombTimer - Time.deltaTime;
        if (BombTimer < 0.75)
        {
            anim.SetBool("Soon", true);
        }
        if (BombTimer < 0)
        {
           Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
           Destroy(gameObject);
        }
    }
}
