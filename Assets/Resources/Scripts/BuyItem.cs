using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuyItem : MonoBehaviour
{
    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }
}
