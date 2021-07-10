using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public string scoreToText;
    public TextMeshProUGUI scoreText;

    public void ScoreGained()
    {
        score++;
    }

    public void Update()
    {
        scoreToText = score.ToString();
        scoreText.text = scoreToText;
    }
}
