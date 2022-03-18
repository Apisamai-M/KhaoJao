using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BtnControl : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;
    public static bool back = false;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }

    public void BackBtn()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        back = true;
        Debug.Log(CoinManager.SumCoin);
        Debug.Log(ShopManagerScript.Allbuy);
        Debug.Log(SceneName);
 
        //CoinManager.SumCoin -= CoinManager.coins;
        if (ShopManagerScript.Allbuy > 0 && (SceneName == "ShopWindow" || SceneName == "ShopWindowLevel2" || SceneName == "ShopWindowLevel3" || SceneName == "ShopWindowLevel4" || SceneName == "ShopWindowLevel5"))
        {
            Debug.Log("test");
            CoinManager.SumCoin += ShopManagerScript.Allbuy;
        }
    }

    public void NextBtn()
    {
        back = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BackToLevelManager()
    {
        SceneManager.LoadScene("LevelManager");
    }
}
