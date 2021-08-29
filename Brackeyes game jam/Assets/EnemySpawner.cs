using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    public GameObject Enemy;
    public bool spawnEnabled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer = spawnTimer - Time.deltaTime;
        if (spawnTimer < 0 && spawnEnabled == true)
        {
            spawnTimer = 4;
            int Spawnpoint = Random.Range(1, 4);
            SpawnEnemy(Spawnpoint);
        }
    }

    public void SpawnEnemy(int Spawnpoint)
    {
        if (Spawnpoint == 1)
        {
            Instantiate(Enemy, Spawn1.position, Quaternion.identity);
        }
        if (Spawnpoint == 2)
        {
            Instantiate(Enemy, Spawn2.position, Quaternion.identity);
        }
        if (Spawnpoint == 3)
        {
            Instantiate(Enemy, Spawn3.position, Quaternion.identity);
        }
        if (Spawnpoint == 4)
        {
            Instantiate(Enemy, Spawn4.position, Quaternion.identity);
        }
    }
}
