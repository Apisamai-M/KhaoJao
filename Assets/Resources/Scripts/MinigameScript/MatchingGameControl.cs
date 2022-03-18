using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchingGameControl : MonoBehaviour
{
    public float currentTime = 0f;
    public Text textBox;
    public Text ScoreTime;
    public Text ScoreMatch;
    public Text ScoreTotal;
    public int scoretime = 0;
    public Text CScoreTime;
    public Text CScoreMatch;
    public Text CScoreTotal;
    public int Cscoretime = 0;
    public GameObject GameOverBox;
    public GameObject GameCompleteBox;
    public static bool GameOver = false;
    public static bool GameComplete = false;
    public static string nextLevel = "Level3Instruction";
    public static MatchingGameControl instance;

    public int total;
    // public int levelToUnlock = 3;
    
    void Awake()
    {
        
        GameCompleteBox.SetActive(false);
        GameOverBox.SetActive(false);
        instance = this;
    }
    void Start()
    {   
        currentTime = TIME.currenttime;     
    }
    
    void Update()
    {
        //check game over
        if(TIME.GameEnd == true)
         {
           GameOverBox.SetActive(true);
           EndGame();
         }
    }

    public void EndGame() {
        scoretime = Mathf.RoundToInt(TIME.currenttime); 
        ScoreMatch.text = matchingGame.count.ToString() + " x 2 = " + (matchingGame.count * 2).ToString();
        ScoreTime.text = scoretime.ToString();
        total = (matchingGame.count * 2) + scoretime;
        Time.timeScale = 0f;
        ScoreTotal.text = total.ToString();
        CoinManager.SumCoin+= total;
        //startingTime = 20;
    }

    public void CompleteGame() {
        Cscoretime = Mathf.RoundToInt(TIME.currenttime); 
        CScoreMatch.text = matchingGame.count.ToString() + " x 2 = " + (matchingGame.count * 2).ToString();
        CScoreTime.text = Cscoretime.ToString();
        total = (matchingGame.count * 2) + Cscoretime;
        CScoreTotal.text = total.ToString();
        CoinManager.SumCoin+= total;
        Debug.Log(total);
        Debug.Log(CoinManager.SumCoin);
        WinLevel();
        
    }

    public void checkwin()
    {
        //  if (matchingGame.count == 4) {
            Time.timeScale = 0f;
            GameComplete = true;
            GameCompleteBox.SetActive(true);
            CompleteGame();
        
    }

    public void WinLevel() {
        Debug.Log("Level Win");
        // PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
