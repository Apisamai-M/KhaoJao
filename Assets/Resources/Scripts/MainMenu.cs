using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string LoadLevel = "LevelManager";
    public string LoadSetting = "Setting";
    public string LoadCollection = "Collection";
    public void PlayGame() {
        SceneManager.LoadScene(LoadLevel);
    }

    public void Setting() {
        SceneManager.LoadScene(LoadSetting);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
