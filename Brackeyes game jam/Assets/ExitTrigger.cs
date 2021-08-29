using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ExitTrigger : MonoBehaviour
{
    public GameObject Spawner;
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
        GetComponentInParent<TilemapCollider2D>().enabled = true;
        GetComponentInParent<TilemapRenderer>().enabled = true;
        Spawner.GetComponent<EnemySpawner>().spawnEnabled = true;
    }
}
