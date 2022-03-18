using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tools : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;
    public Transform cursorObj;
    public GameObject prefabSprite; 
    public GameObject prefabPlant;
    public GameObject Object_drag;
    public int Id;
    public static int AllowClick = 0;
    public static int ChilliQuantity = 0;
    public static int maxChilli = 0;
    public static int AllowChilli = 0;
    public static int NapaQuantity = 0;
    public static int maxNapa = 0;
    public static int AllowNapa = 0;
    public static int maxCK = 0;
    public static int AllowCK = 0;
    public static int CKQuantity = 0;
    public static int maxBasil = 0;
    public static int AllowBasil = 0;
    public static int BasilQuantity = 0;
    public static int pesticideQuantity = 0;
    public static int maxPesticide = 0;
    public static int AllowPesticide = 0;
    public static int maxGalangal = 0;
    public static int AllowGalangal = 0;
    public static int GalangalQuantity = 0;
    public static int maxCoriander = 0;
    public static int AllowCoriander = 0;
    public static int CorianderQuantity = 0;
    

    public void Awake()
    {
        AllowClick = (ButtonInfo.Item1 + ButtonInfo.Item2 + ButtonInfo.Item3 + ButtonInfo.Item4 + ButtonInfo.Item6 + ButtonInfo.Item7);

        if (Id == 1)
        {
            maxChilli = ButtonInfo.Item1;
            AllowChilli = ButtonInfo.Item1;
            ChilliQuantity = ButtonInfo.Item1;
        }
        if (Id == 2)
        {
            maxCK = ButtonInfo.Item2;
            AllowCK = ButtonInfo.Item2;
            CKQuantity = ButtonInfo.Item2;
        }
        if (Id == 3)
        {
            maxNapa = ButtonInfo.Item3;
            AllowNapa = ButtonInfo.Item3;
            NapaQuantity = ButtonInfo.Item3;
        }
        if (Id == 4)
        {
            maxBasil = ButtonInfo.Item4;
            AllowBasil = ButtonInfo.Item4;
            BasilQuantity = ButtonInfo.Item4;
        }
        if (Id == 5)
        {
            maxPesticide = ButtonInfo.Item5;
            AllowPesticide = ButtonInfo.Item5;
            pesticideQuantity = ButtonInfo.Item5;
        }
        if (Id == 6)
        {
            maxGalangal = ButtonInfo.Item6;
            AllowGalangal = ButtonInfo.Item6;
            GalangalQuantity = ButtonInfo.Item6;
        }
        if (Id == 7)
        {
            maxCoriander = ButtonInfo.Item7;
            AllowCoriander = ButtonInfo.Item7;
            CorianderQuantity = ButtonInfo.Item7;
        }
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        Debug.Log(AllowClick);
    }

    void OnMouseDown()
    {
        if (gameObject.name == "watering_can") {
            GMScript.currentTool = "watering";
        }

        if (gameObject.name == "Chilli") {
            GMScript.currentTool = "Chilli";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "napa") {
            GMScript.currentTool = "Napa";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "ChineseKale") {
            GMScript.currentTool = "ChineseKale";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "Basil") {
            GMScript.currentTool = "Basil";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "Galangal") {
            GMScript.currentTool = "Galangal";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "Coriander") {
            GMScript.currentTool = "Coriander";
            Debug.Log(GMScript.currentTool);
        }

        if (gameObject.name == "scythe") {
            GMScript.currentTool = "scythe";
        }

        if (gameObject.name == "pesticide") {
            GMScript.currentTool = "pesticide";
        }

        //Mouse Highlight
        if (SceneName == "Level1") {
            if ((PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false)) {
                cursorObj.transform.position = transform.position;
                Debug.Log(GMScript.currentTool);
                Debug.Log(GMScript.currentClick);
            }
        }

        if (SceneName == "Level2") {
            if ((PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false)) {
                cursorObj.transform.position = transform.position;
                Debug.Log(GMScript.currentTool);
                Debug.Log(GMScript.currentClick);
            }
        }

        if (SceneName == "Level3") {
            if ((PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false)) {
                cursorObj.transform.position = transform.position;
                Debug.Log(GMScript.currentTool);
                Debug.Log(GMScript.currentClick);
            }
        }

        if (SceneName == "Level4") {
            if ((PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false)) {
                cursorObj.transform.position = transform.position;
                Debug.Log(GMScript.currentTool);
                Debug.Log(GMScript.currentClick);
            }
        }

        if (SceneName == "Level5") {
            if ((PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false)) {
                cursorObj.transform.position = transform.position;
                Debug.Log(GMScript.currentTool);
                Debug.Log(GMScript.currentClick);
            }
        }
       
        
    }

    public void StartRecharge()
    {
        Destroy(prefabSprite);
        GMScript.currentSeed = null;
    }
}
