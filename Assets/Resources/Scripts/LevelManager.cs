using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public SceneFader fader;
    public Button[] levelButtons;
    //level1
    public GameObject[] stars;
    public GameObject[] noStars;
    //level2
    public GameObject[] stars2;
    public GameObject[] noStars2;
    //level3
    public GameObject[] stars3;
    public GameObject[] noStars3;
    //level4
    public GameObject[] stars4;
    public GameObject[] noStars4;
    //level5
    public GameObject[] stars5;
    public GameObject[] noStars5;

    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("StarLevel1"));
        DisplayStarLevel1();
        DisplayStarLevel2();
        DisplayStarLevel3();
        DisplayStarLevel4();
        DisplayStarLevel5();
        
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        for(int i = 0; i < levelButtons.Length; i++ ) {
            if(i + 1 > levelReached) {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void Select (string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void DisplayStarLevel1() {
        if (PlayerPrefs.GetInt("StarLevel1") == 1) {
            stars[0].SetActive(true);
            noStars[1].SetActive(true);
            noStars[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel1") == 2) {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            noStars[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel1") == 3) {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else {
            noStars[0].SetActive(true);
            noStars[1].SetActive(true);
            noStars[2].SetActive(true);
        }
    }

    public void DisplayStarLevel2() {
        if (PlayerPrefs.GetInt("StarLevel2") == 1) {
            stars2[0].SetActive(true);
            noStars2[1].SetActive(true);
            noStars2[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel2") == 2) {
            stars2[0].SetActive(true);
            stars2[1].SetActive(true);
            noStars2[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel2") == 3) {
            stars2[0].SetActive(true);
            stars2[1].SetActive(true);
            stars2[2].SetActive(true);
        }
        else {
            noStars2[0].SetActive(true);
            noStars2[1].SetActive(true);
            noStars2[2].SetActive(true);
        }
    }

    public void DisplayStarLevel3() {
        if (PlayerPrefs.GetInt("StarLevel3") == 1) {
            stars3[0].SetActive(true);
            noStars3[1].SetActive(true);
            noStars3[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel3") == 2) {
            stars3[0].SetActive(true);
            stars3[1].SetActive(true);
            noStars3[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel3") == 3) {
            stars3[0].SetActive(true);
            stars3[1].SetActive(true);
            stars3[2].SetActive(true);
        }
        else {
            noStars3[0].SetActive(true);
            noStars3[1].SetActive(true);
            noStars3[2].SetActive(true);
        }
    }

    public void DisplayStarLevel4() {
        if (PlayerPrefs.GetInt("StarLevel4") == 1) {
            stars4[0].SetActive(true);
            noStars4[1].SetActive(true);
            noStars4[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel4") == 2) {
            stars4[0].SetActive(true);
            stars4[1].SetActive(true);
            noStars4[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel4") == 3) {
            stars4[0].SetActive(true);
            stars4[1].SetActive(true);
            stars4[2].SetActive(true);
        }
        else {
            noStars4[0].SetActive(true);
            noStars4[1].SetActive(true);
            noStars4[2].SetActive(true);
        }
    }

    public void DisplayStarLevel5() {
        if (PlayerPrefs.GetInt("StarLevel5") == 1) {
            stars5[0].SetActive(true);
            noStars5[1].SetActive(true);
            noStars5[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel5") == 2) {
            stars5[0].SetActive(true);
            stars5[1].SetActive(true);
            noStars5[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("StarLevel5") == 3) {
            stars5[0].SetActive(true);
            stars5[1].SetActive(true);
            stars5[2].SetActive(true);
        }
        else {
            noStars5[0].SetActive(true);
            noStars5[1].SetActive(true);
            noStars5[2].SetActive(true);
        }
    }
}
