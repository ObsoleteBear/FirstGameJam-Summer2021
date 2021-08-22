using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Random = UnityEngine.Random;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies;

    public LevelManager levelManager;

    public GameObject enemyPrefab;
    public Disable door;
    public Transform Parnt;

    public Vector2 spawnPos;
    public Vector3 NextRoomPos;

    public float spawnNumber;
    public float spawnCounter;
    public List<GameObject> deadEnemies;

    public bool RoomSpawned;


    void Awake()
    {
        Parnt = gameObject.GetComponentInParent<Transform>();
        door = gameObject.GetComponentInChildren<Disable>();
        NextRoomPos = new Vector3(Parnt.position.x, Parnt.position.y + 5f, Parnt.transform.position.z);
        spawnNumber = Random.Range(2, 5);
        for (spawnCounter = 0; spawnCounter < spawnNumber; spawnCounter++)
        {
            spawnPos = new Vector2(Random.Range(gameObject.transform.position.x - 7, gameObject.transform.position.x + 7), Random.Range(gameObject.transform.position.y - 4, gameObject.transform.position.y + 4));
            GameObject NewEnemy = Instantiate(enemyPrefab, spawnPos, quaternion.identity);
            enemies.Add(NewEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(RoomSpawned == false && collision.tag == "WallCollider")
        {
            levelManager.LoadNextRoom(NextRoomPos);
            RoomSpawned = true;
        }
    }

    private void Update()
    {
        int countNull = 0;

        for (int i = 0; i < enemies.Count(); i++)
        {
            if (enemies[i] == null)
            {
                countNull++;
            }
        }

        if (countNull == enemies.Count)
        {
            door.DisableObject();
        }
        //{
        //    door.DisableObject();
        //}

        //    if (enemies[0] == null && enemies[1] == null)
        //    {
        //    if (spawnNumber == 2)
        //    {
        //        door.DisableObject();
        //    }else if (enemies[2] == null)
        //    {
        //        if (spawnNumber == 3)
        //        {
        //            door.DisableObject();
        //        } else if (enemies[3] == null)
        //        {
        //            if (spawnNumber == 4)
        //            {
        //                door.DisableObject();
        //            }
        //            else if (enemies[4] == null)
        //            {
        //                if (spawnNumber == 5)
        //                {
        //                    door.DisableObject();
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
