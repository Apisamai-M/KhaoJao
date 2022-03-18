using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarHandler : MonoBehaviour
{
    public GameObject[] stars;
    public GameObject[] noStars;
    public Scene currentScene;
    public string SceneName;
    
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
    }

    public void starAchieved() {
        StarLevel1();
        StarLevel2();
        StarLevel3();
        StarLevel4();
        StarLevel5();
    }

    public void StarLevel1() {
        if (SceneName == "Level1") {
            if (CoinManager.coins >= 50 && CoinManager.coins < 85) {
                stars[0].SetActive(true);
                noStars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel1", 1);
            }
            if (CoinManager.coins >= 85 && CoinManager.coins < 120) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel1", 2);
            }
            if (CoinManager.coins >= 120) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel1", 3);
            }
        }
    }

    public void StarLevel2() {
        if (SceneName == "Level2") {
            if (CoinManager.coins >= 100 && CoinManager.coins < 135) {
                stars[0].SetActive(true);
                noStars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel2", 1);
            }
            if (CoinManager.coins >= 135 && CoinManager.coins < 170) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel2", 2);
            }
            if (CoinManager.coins >= 170) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel2", 3);
            }
        }
    }

    public void StarLevel3() {
        if (SceneName == "Level3") {
            if (CoinManager.coins >= 120 && CoinManager.coins < 155) {
                stars[0].SetActive(true);
                noStars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel3", 1);
            }
            if (CoinManager.coins >= 155 && CoinManager.coins < 185) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel3", 2);
            }
            if (CoinManager.coins >= 185) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel3", 3);
            }
        }
    }

    public void StarLevel4() {
        if (SceneName == "Level4") {
            if (CoinManager.coins >= 150 && CoinManager.coins < 185) {
                stars[0].SetActive(true);
                noStars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel4", 1);
            }
            if (CoinManager.coins >= 185 && CoinManager.coins < 220) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel4", 2);
            }
            if (CoinManager.coins >= 220) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel4", 3);
            }
        }
    }

    public void StarLevel5() {
        if (SceneName == "Level5") {
            if (CoinManager.coins >= 150 && CoinManager.coins < 185) {
                stars[0].SetActive(true);
                noStars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel5", 1);
            }
            if (CoinManager.coins >= 185 && CoinManager.coins < 220) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                noStars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel5", 2);
            }
            if (CoinManager.coins >= 220) {
                stars[0].SetActive(true);
                stars[1].SetActive(true);
                stars[2].SetActive(true);

                PlayerPrefs.SetInt("StarLevel5", 3);
            }
        }
    }
}
