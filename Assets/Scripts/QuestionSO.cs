using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    [SerializeField]
    [TextArea(2, 5)]
    string question = "Enter new question text here";

    [SerializeField]
    string[] answers = new string[4];

    [SerializeField]
    int correctAnswerIndex;
 
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int Index)
    {
        return answers[Index];
    }

}
