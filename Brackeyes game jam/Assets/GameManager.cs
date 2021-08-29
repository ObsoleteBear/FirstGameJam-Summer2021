using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool ArenaMode;
    public bool MainMenu;
    public bool TutorialMode;
    public int LevelNum;
    public bool Pause;
    public int KilledEnemies;
    public int HighScore;
    public bool PlayerDead;
    public GameObject Transition;
    public GameObject HighScoreDisplay;
    public GameObject HighScoreText;
    void Update()
    {
        if (KilledEnemies > HighScore)
        {
            HighScore = KilledEnemies;
        }
        if (GameObject.FindGameObjectWithTag("GameManager") == null)
        {
            DontDestroyOnLoad(gameObject);
        }

        if(PlayerDead == true && Input.GetButtonDown("Ability") && ArenaMode == true)
        {
            ArenaButton();
            PlayerDead = false;
        }
        if (PlayerDead == true && Input.GetButtonDown("Escape") && ArenaMode == true)
        {
            MainMenuButton();
            PlayerDead = false;
        }else if (Input.GetButtonDown("Escape") && TutorialMode == true)
        {
            MainMenuButton();

        }
    }
    public void PlayerDeath(GameObject Player)
    {
        PlayerDead = true;
        Player.GetComponent<Controller>().enabled = false;
        Player.GetComponent<AbilityManager>().enabled = false;
        Player.GetComponent<Rigidbody2D>().simulated = false;
        HighScoreText.GetComponent<TextMeshProUGUI>().enabled = true;
        HighScoreDisplay.GetComponent<TextMeshProUGUI>().enabled = true;
        HighScoreDisplay.GetComponent<TextMeshProUGUI>().text = HighScore.ToString();
    }

    public void EnemyDeath(GameObject enemy)
    {
        Destroy(enemy, 0.3f);
        KilledEnemies = KilledEnemies + 1;
    }
    public void MainMenuButton()
    {
        ArenaMode = false;
        TutorialMode = false;
        MainMenu = true;
        Transition.GetComponent<Animator>().SetBool("Transition", true);
    }
    public void ArenaButton()
    {
        TutorialMode = false;
        MainMenu = false;
        ArenaMode = true;
        Transition.GetComponent<Animator>().SetBool("Transition", true);
    }
    public void TutorialButton()
    {

    }
    public void LoadLevel()
    {
        if (MainMenu == true)
        {
            HighScoreText.GetComponent<TextMeshProUGUI>().enabled = false;
            HighScoreDisplay.GetComponent<TextMeshProUGUI>().enabled = false;
            KilledEnemies = 0;
            SceneManager.LoadScene(0);
        } else if(ArenaMode == true)
        {
            HighScoreText.GetComponent<TextMeshProUGUI>().enabled = false;
            HighScoreDisplay.GetComponent<TextMeshProUGUI>().enabled = false;
            KilledEnemies = 0;
            SceneManager.LoadScene(1);
        }
    }
    public void SussyAmogus()
    {
        Application.Quit();
    }
}
