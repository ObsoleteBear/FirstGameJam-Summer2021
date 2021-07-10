using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }
}
