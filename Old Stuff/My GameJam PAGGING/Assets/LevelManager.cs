using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Mathematics;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float Timer;

    public bool reachedPos = false;
    public bool atPos;
    public bool ShouldMove;

    public GameObject Player;
    public GameObject roomPrefab;

    public int SceneName;

    public Camera cam;

    public Vector3 CamPosition;
    public Vector3 MovePlayer;

    public bool TransitionComplete = false;
    private void Start()
    {
        SceneName = SceneManager.GetActiveScene().buildIndex;
        cam = FindObjectOfType<Camera>();
        CamPosition = new Vector3(12, 12, -12);
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player" && TransitionComplete == false)
        {
            ShouldMove = true;
            CamPosition = new Vector3(cam.transform.position.x, cam.transform.position.y + 10f, -10);
            TransitionComplete = true;
            MovePlayer = new Vector2(Player.transform.position.x, Player.transform.position.y + 2);
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown("space") && Player == null)
        {
            Debug.Log("input detected");
            SceneManager.LoadScene(SceneName);
        }

        cam = FindObjectOfType<Camera>();
        if (reachedPos == false && ShouldMove == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, CamPosition, 15 * Time.deltaTime);
        }
        if (cam.transform.position == CamPosition)
        {
            reachedPos = true;
        }
    }
    public void LoadNextRoom(Vector3 pos)
    {
        Instantiate(roomPrefab, pos, quaternion.identity);
    }
}
