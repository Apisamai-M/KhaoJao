using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChange : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;    
    }

    public void ChangePage() {
        if (SceneName == "Level1Instruction") {
            SceneManager.LoadScene("Level1InstructionDetail");
        }

        if (SceneName == "Level2Instruction") {
            SceneManager.LoadScene("Level2InstructionDetail");
        }

        if (SceneName == "Level3Instruction") {
            SceneManager.LoadScene("Level3InstructionDetail");
        }

        if (SceneName == "Level4Instruction") {
            SceneManager.LoadScene("Level4InstructionDetail");
        }

        if (SceneName == "Level5Instruction") {
            SceneManager.LoadScene("Level5InstructionDetail");
        }
    }
}
