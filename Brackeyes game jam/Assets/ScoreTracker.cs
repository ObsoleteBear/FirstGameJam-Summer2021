using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public GameManager GameMan;
    public TextMeshProUGUI textD;
    // Start is called before the first frame update
    void Start()
    {
        GameMan = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textD.text = GameMan.KilledEnemies.ToString();
    }
}
