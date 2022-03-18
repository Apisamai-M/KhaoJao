using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownLevel2 : MonoBehaviour
{
    public float timeStart = 60f;
    public Text textBox;
    public Text TitleText;
    public Text Coin;
    public Text Target;
    public Text CCoin;
    public Text CTarget;
    public GameObject CanvasGameover;
    public GameObject CanvasComplete;
    public static int complete = 100;
    public static bool GameOver = false;
    public static bool GameComplete = false;
    public static string nextLevel = "Minigame";
    public int levelToUnlock = 3;
    public int count = 0;
    //public bool GameComplete = false;


    void Awake()
    {
        Time.timeScale = 1f;
        GameComplete = false;
        GameOver = false;
        count = 0;
    }
    void Start()
    {
        textBox.text = timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySFX();
        if (!GameOver)
        {
            timeStart -= Time.deltaTime;
            textBox.text = Mathf.Round(timeStart).ToString();
            if (timeStart <= 6) {
                textBox.color = Color.red;
            }
        }
        if (timeStart <= 0 && CoinManager.coins < complete) //timeup and cannot complete sell goal
        {
            Debug.Log("GameOver");
            GameOver = true;
            CanvasGameover.SetActive(true);
            Target.text = complete.ToString();
            Coin.text = CoinManager.coins.ToString();
            timeStart = 120;
            count++;
        }
        if (timeStart <= 0 && CoinManager.coins >= complete) //timeup and can complete sell goal
        {
            Debug.Log("Complete");
            GetComponent<StarHandler>().starAchieved();
            GameComplete = true;
            if (PlayerPrefs.GetInt("levelReached") < levelToUnlock) {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }
            Time.timeScale = 0f;
            CTarget.text = complete.ToString();
            CCoin.text = CoinManager.coins.ToString();
            CanvasComplete.SetActive(true);
            count++;
        }
        if (plantControl.count == 0 && tools.AllowClick == 0 && CoinManager.coins >= complete) { //seed is out of stock and can complete sell goal
            Debug.Log("Complete");
            GetComponent<StarHandler>().starAchieved();
            GameComplete = true;
            if (PlayerPrefs.GetInt("levelReached") < levelToUnlock) {
                PlayerPrefs.SetInt("levelReached", levelToUnlock);
            }
            Time.timeScale = 0f;
            CTarget.text = complete.ToString();
            CCoin.text = CoinManager.coins.ToString();
            CanvasComplete.SetActive(true);
            count++;
        }
        if (plantControl.count == 0 && tools.AllowClick == 0 && CoinManager.coins < complete) { //seed is out of stock and cannot complete sell goal
            Debug.Log("GameOver");
            TitleText.text = "Oh! you run out of the seed.";
            GameOver = true;
            CanvasGameover.SetActive(true);
            Target.text = complete.ToString();
            Coin.text = CoinManager.coins.ToString();
            timeStart = 120;
            count++;
        }
    }

    public void PlaySFX()
    {
        Debug.Log(count);
        if (GameOver == true && count <= 5) {
            SFXManager.GameSound("GameOver");
        }
        if (GameComplete == true && count <= 5) {
            SFXManager.GameSound("Win");
        }
    }
}
