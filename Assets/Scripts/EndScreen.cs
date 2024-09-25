using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        ShowFinalScore();
    }

    public void ShowFinalScore()
    {
        finalScoreText.text = "Well done!\n You got a score of " + scoreKeeper.CalculateScore() + "%";
    }
}
