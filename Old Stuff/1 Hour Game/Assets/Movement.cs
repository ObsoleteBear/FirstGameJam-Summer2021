using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public Transform TopPos;
    public Transform BottomPos;
    public float MoveSpeed;
    public bool TowardsTop;
    public bool TowardsBottom;
    public float Health;
    public Vector2 random;
    public float timer;
    public float betweenObstacles;
    public float speed;
    public SpriteRenderer lol;
    public GameObject[] myObjects;
    public bool playerisDead = false;
    // Start is called before the first frame update
    void Start()
    {
        TowardsTop = true;
    }

    // Update is called once per frame
    void Update()
    {
        random = new Vector2(11, Random.Range(5f, -5f));
        if (transform.position == TopPos.position)
        {
            TowardsBottom = true;
            TowardsTop = false;
        }
        if (transform.position == BottomPos.position)
        {
            TowardsTop = true;
            TowardsBottom = false;
        }
        if (Input.GetKeyDown("space"))
        {
            if (TowardsTop == true)
            {
                TowardsBottom = true;
                TowardsTop = false;
            } else
            {
                TowardsBottom = false;
                TowardsTop = true;
            }
            if (playerisDead == true)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Health <= 0)
        {
            lol.enabled = false;
            playerisDead = true;
        }
        int randomIndex = Random.Range(0, myObjects.Length);
        timer = timer + speed;

        if (timer >= betweenObstacles)
        {
            GameObject Obstacle = Instantiate(myObjects[randomIndex], random, Quaternion.identity) as GameObject;
            timer = 0;
        }

}
    private void FixedUpdate()
    {
        if (TowardsBottom == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, BottomPos.position, MoveSpeed);
        }
        else if (TowardsTop == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, TopPos.position, MoveSpeed);
        }
    }
}
