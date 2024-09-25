using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeToCompleteQuestion = 10f;
    public float timeToShowNextQuestion = 5f;

    QuizScript quiz;

    public float fillFraction;
    public float timerValue;

    void Start()
    {
        timerValue = timeToCompleteQuestion;
        quiz = FindObjectOfType<QuizScript>();
    }
    void Update()
    {
        UpdateTimer();
    }

    public void ResetTimer()
    {
        timerValue = timeToCompleteQuestion;
    }

    void UpdateTimer()
    {
        if (quiz.answeringQuestionState == true)
        {
            if (timerValue > 0 )
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            if (timerValue <= 0 )
            {
                fillFraction = 0;
                timerValue = timeToShowNextQuestion;
                quiz.answeringQuestionState = false;
                quiz.SetButtonState(false);
            }
        }
        else 
        {
            if (quiz.playerAnsweredState == false)  
                {
                    if (timerValue > 0)
                    {
                        fillFraction = timerValue / timeToShowNextQuestion;
                        quiz.DisplayAnswer(-1);
                    }
                    if (timerValue <= 0)
                    {
                        quiz.loadNextQuestion = true;
                    }
                }
            if (quiz.playerAnsweredState == true)  
            {
                if (timerValue > 0)
                {
                    fillFraction = timerValue / timeToShowNextQuestion;
                }
                if (timerValue <= 0)
                {
                    quiz.loadNextQuestion = true;
                }
            }
        }
        timerValue -= Time.deltaTime;
        Debug.Log(timerValue);
    }
}
