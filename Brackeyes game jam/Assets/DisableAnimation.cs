using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAnimation : MonoBehaviour
{
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StopLoop()
    {
        GetComponent<Animator>().SetBool("Transition", false);
    }
    public void ReferenceGameManager()
    {
        GM.LoadLevel();
    }
}
