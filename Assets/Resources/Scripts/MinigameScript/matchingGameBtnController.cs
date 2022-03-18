using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class matchingGameBtnController : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;

    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }
    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void LevelSelection() 
    {
        SceneManager.LoadScene("LevelManager");
    }
     public void NextLevel() {
        if (SceneName == "MiniGame") {
            SceneManager.LoadScene("Level3Instruction");
        }

        if (SceneName == "MiniGame3") {
            SceneManager.LoadScene("Level4Instruction");
        }

        if (SceneName == "MiniGame2") {
            SceneManager.LoadScene("Level5Instruction");
        }
    }

    public void Retry() 
    {
            SceneManager.LoadSceneAsync(SceneName);
        
    }
}
