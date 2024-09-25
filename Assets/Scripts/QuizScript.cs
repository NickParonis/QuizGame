using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class QuizScript : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questionList;
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    [SerializeField] int correctAnswerIndex;


    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswserSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("State")]
    public bool answeringQuestionState;
    public bool playerAnsweredState;
    public bool loadNextQuestion;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    public bool isComplete;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    void Start()
    {
        isComplete = false;
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = questionList.Count;
        progressBar.value = 0;
        scoreText.text = "Score: 0%";
        timer = FindObjectOfType<Timer>();
        SetButtonState(true);
        GetRandomQuestion();
        DisplayQuestion();
        ResetQuestionState();
    }

    void ResetQuestionState()
    {
        playerAnsweredState = false;
        answeringQuestionState = true;
        loadNextQuestion = false;
        timer.ResetTimer();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (loadNextQuestion == true)
        {
            if (progressBar.value == progressBar.maxValue)
                {
                    isComplete = true;
                }
            ResetQuestionState();
            GetRandomQuestion();
            DisplayQuestion();
            SetButtonState(true);
        }
    }

    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);
        SetButtonState(false);
        answeringQuestionState = false;
        timer.timerValue = timer.timeToShowNextQuestion;
        playerAnsweredState = true;
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";
    }


    void DisplayQuestion()
    {
        scoreKeeper.IncrementQuestionsSeen();
        progressBar.value++;
        questionText.text = currentQuestion.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswserSprite;
        }
    }

    void GetRandomQuestion()
    {

        int index = Random.Range(0, questionList.Count);
        currentQuestion = questionList[index];
        if (questionList.Contains(currentQuestion))
        {
            questionList.Remove(currentQuestion);
        }
    }

    public void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    public void DisplayAnswer(int index)
    {
        var correctIndex = currentQuestion.GetCorrectAnswerIndex();
        if (index == correctIndex)
        {
            questionText.text = "Correct";
            Image buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.IncrementCorrectAnswers();
        }
        else
        {
            var correctAnswer = currentQuestion.GetAnswer(correctIndex);
            questionText.text = "Wrong Answer. Correct Answer was " + correctAnswer;
            Image buttonImage = answerButtons[correctIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
