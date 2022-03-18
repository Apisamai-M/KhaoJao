using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;
    public GameObject hint;
    public Text hinttext;

    [SerializeField] private GameObject gameover;
    [SerializeField] private GameObject gameComplete;

    [SerializeField] private string[] hintanswer;
    [SerializeField] private QuizDataScriptable questionData;
    [SerializeField] private Image questionImage;
    [SerializeField] private WordData[] answerWordArray;
    [SerializeField] private WordData[] optionsWordArray;
    // Start is called before the first frame update

    private GameStatus gameStatus = GameStatus.Playing;
    private int currentAnswerIndex = 0 , currentQuestionIndex = 0;
    private bool correctAnswer = true;
    private string answerWord;
    public static int reward;

    

    private int score = 0;
    private List<int> selectedWordIndex;
    private char[] charArray = new char[12];

    private void Awake()
    {
        if (instance == null) 
            {
                instance = this;
            }
        else
            {
                Destroy(gameObject);
            }
    }

    private void Start()
    {
        gameover.SetActive(false);
        gameComplete.SetActive(false);
        selectedWordIndex = new List<int>();
        SetQuestion();
    }

    private void Update()
    {
        //check game over
        if(TIME.GameEnd == true)
         {
           gameover.SetActive(true);
         }
    }

    public void SetQuestion()
    {
        gameStatus = GameStatus.Playing;
        answerWord = questionData.questions[currentQuestionIndex].answer; 
        questionImage.sprite = questionData.questions[currentQuestionIndex].questionImage;
       
        ResetQuestion();

        selectedWordIndex.Clear();
        Array.Clear(charArray, 0, charArray.Length);
        //currentAnswerIndex = 0;

        for (int i = 0; i < answerWord.Length; i++)
        {
            charArray[i] = char.ToUpper(answerWord[i]);
        }

        for (int j = answerWord.Length; j < /*optionsWordArray*/charArray.Length; j++)
        {
            charArray[j] = (char)UnityEngine.Random.Range(65, 91);
        }

        charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();

        for (int k = 0; k < optionsWordArray.Length; k++)
        {
            optionsWordArray[k].SetChar(charArray[k]);
        }
    

        //currentQuestionIndex++;
    }

    public void SelectedOption(WordData wordData)
    {
        if (gameStatus == GameStatus.Next || currentAnswerIndex == answerWord.Length) return;
        
        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());
        wordData.gameObject.SetActive(false);
        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        
        currentAnswerIndex++;
        

        if (currentAnswerIndex == answerWord.Length)
        {
            correctAnswer = true;

            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordArray[i].charValue))
                {
                    correctAnswer = false;
                    break;
                }
            }
                if (correctAnswer)
                {
                    gameStatus = GameStatus.Next;
                    currentQuestionIndex++;
                    score += 50;

                    Debug.Log("We have answered correct" + score);

                    if (currentQuestionIndex < questionData.questions.Count)
                    {
                        hint.SetActive(false);
                        Invoke("SetQuestion", 0.2f);
                    }
                    else
                    {
                        ShopManagerScript.minigamecomplete = true;
                        CoinManager.SumCoin += 50;
                        gameComplete.SetActive(true);
                        Time.timeScale = 0f;
                        
                    }
                }
               
            }
        
    }

    private void ResetQuestion()
    {
         
            
        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');
                    //answerWordArray[i].SetChar(answerWord[i]);
        }

        for (int i = answerWord.Length; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].gameObject.SetActive(true);
        }
        
        currentAnswerIndex = 0;
    }
    public void ResetLastWord()
    {        
        if (selectedWordIndex.Count > 0)
        {
            int index = selectedWordIndex[selectedWordIndex.Count - 1];
            optionsWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count - 1);
            
            currentAnswerIndex--;
            answerWordArray[currentAnswerIndex].SetChar('_');
        }

    }
       public void whenButtonClicked()
    {
        if(hint.activeInHierarchy == false)
        {
            hint.SetActive(true);
            hinttext.text = hintanswer[currentQuestionIndex];
        }
    }

    public void getreward()
    {
        ShopManagerScript.instance.morepesticide(2);
    }
}

[System.Serializable]

public class QuestionData
{
    public Sprite questionImage;
    public string answer;
}



public enum GameStatus
{
    Playing,
    Next
}