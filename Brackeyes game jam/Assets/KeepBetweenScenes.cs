using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBetweenScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Transition") == null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
