using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManagerGame3 : MonoBehaviour
{
    // Start is called before the first frame update
    public static QuizManagerGame3 instance;

    public List<QuestionandAnswer> QandA;
    public GameObject[] options;
    public int currentQuestion;
    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject gameComplete;

    public static int reward;

    public Text QuestionText;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameover.SetActive(false);
        gameComplete.SetActive(false);
        generateQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        //check game over
        if (TIME.GameEnd == true)
        {
            gameover.SetActive(true);
        }
    }


    void generateQuestion()
    {
        if (QandA.Count > 0)
        {
            currentQuestion = Random.Range(0, QandA.Count);

            QuestionText.text = QandA[currentQuestion].Question;
            SetAnswers();

        }
        else
        {
            Debug.Log("Out of questions");
            gameComplete.SetActive(true);
            ShopManagerScript.minigamecomplete = true;
            CoinManager.SumCoin += 25;
            Time.timeScale = 0f;
        }

    }

    public void correct()
    {
        Debug.Log("correct");
        QandA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QandA[currentQuestion].Answer[i];

            if (QandA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }

        }
    }

    public void getreward()
    {
        ShopManagerScript.instance.morepesticide(1);
    }
}
