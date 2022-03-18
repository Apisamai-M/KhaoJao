using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerGame3 quizManagerGame3;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Corrrect Answer");
            quizManagerGame3.correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }
}
