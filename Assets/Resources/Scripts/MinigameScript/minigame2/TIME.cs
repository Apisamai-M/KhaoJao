using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TIME : MonoBehaviour
{
    public static TIME instance;
    public Text Clock;
    [SerializeField] private float GameTime;
    public static float currenttime;

    public static bool GameEnd;
  


    void Awake()
    {
        GameEnd = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        runtime();
    }

    void Start()
    {
        
        Clock.text = GameTime.ToString();
    }

    void runtime()
    {
        //(count down th time)
        if(GameTime >= 0 )
        {
            GameTime = GameTime - Time.deltaTime;
            Clock.text = Mathf.Round(GameTime).ToString();

            if( GameTime <= 6)
            {
                //Debug.Log(GameTime);
                Clock.color = Color.red;
            }
            currenttime = GameTime;
        }

        else
        {
            GameEnd = true;
        }
     
    }

   




}
