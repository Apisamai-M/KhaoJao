using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }
    public void PlayLevel()
    {
    ShopManagerScript.minigamecomplete = false;

        if (SceneName == "ShopWindow") {
            SceneManager.LoadScene("Level1");
        }

        if (SceneName == "ShopWindowLevel2") {
            SceneManager.LoadScene("Level2");
        }

        if (SceneName == "ShopWindowLevel3") {
            SceneManager.LoadScene("Level3");
        }

        if (SceneName == "ShopWindowLevel4") {
            SceneManager.LoadScene("Level4");
        }

        if (SceneName == "ShopWindowLevel5") {
            SceneManager.LoadScene("Level5");
        }
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void LevelSelection() {
        SceneManager.LoadScene("LevelManager");
    }

    public void NextLevel() {
        if (SceneName == "Level1") {
            SceneManager.LoadScene("Level2Instruction");
        }

        if (SceneName == "Level2") {
            SceneManager.LoadScene("MiniGame");
        }

        if (SceneName == "Level3") {
            SceneManager.LoadScene("MiniGame3");
        }

        if (SceneName == "Level4") {
            SceneManager.LoadScene("MiniGame2");
        }

        if (SceneName == "Level5") {
            SceneManager.LoadScene("Endcredit");
        }
    }

    public void Retry() {
        if (SceneName == "Level1") {
            SceneManager.LoadSceneAsync("Level1Instruction");
        }

        if (SceneName == "Level2") {
            SceneManager.LoadSceneAsync("Level2Instruction");
        }

        if (SceneName == "Level3") {
            SceneManager.LoadSceneAsync("Level3Instruction");
        }

        if (SceneName == "Level4") {
            SceneManager.LoadSceneAsync("Level4Instruction");
        }

        if (SceneName == "Level5") {
            SceneManager.LoadSceneAsync("Level5Instruction");
        }
    }
}
