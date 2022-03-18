using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    public void Restartgame()
    {
        CoinManager.SumCoin = 100;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync("LevelManager");
    }
}
