using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class plantControl : MonoBehaviour
{
    public Scene currentScene;
    public string SceneName;
    public Transform plot;
    public Transform status;
    public string watered = "n";
    public Sprite waterPlot;
    public Sprite UnwaterPlot;
    public Sprite noPlantObj;
    public Sprite deadPlant;
    //Chilli Sprite
    public Sprite seedChilli;
    public Sprite sproutChilli;
    public Sprite growthChilli;
    public Sprite flowerChilli;
    public Sprite harvestChilli;
    //Napa Sprite
    public Sprite seedNapa;
    public Sprite sproutNapa;
    public Sprite growthNapa;
    public Sprite harvestNapa;
    //ChineseKale Sprite
    public Sprite seedCK;
    public Sprite sproutCK;
    public Sprite growthCK;
    public Sprite harvestCK;
    //Basil Sprite
    public Sprite seedBasil;
    public Sprite sproutBasil;
    public Sprite growthBasil;
    public Sprite harvestBasil;
    //Galangal Sprite
    public Sprite seedGalangal;
    public Sprite sproutGalangal;
    public Sprite growthGalangal;
    public Sprite harvestGalangal;
    //Coriander Sprite
    public Sprite seedCoriander;
    public Sprite sproutCoriander;
    public Sprite growthCoriander;
    public Sprite harvestCoriander;
    //Status Sprite
    public Sprite noObject;
    public Sprite StatusNeedWater;
    public Sprite StatusLove;
    public Sprite StatusHarvest;
    public Sprite StatusPest;
    public float growTimeChilli = 0;
    public float growTimeNapa = 0;
    public float growTimeCK = 0;
    public float growTimeBasil = 0;
    public float growTimeGalangal = 0;
    public float growTimeCoriander = 0;
    public int Rand = 0;
    int chilliPrice = 7;
    int NapaPrice = 20;
    int CKPrice = 15;
    int BasilPrice = 5;
    int GalangalPrice = 10;
    int CorianderPrice = 15;
    int DeadPlant = 0;
    public float waitForWater = 0f;
    public float waitForPest = 0f;
    public float waitToHarvest = 0f;
    public string pest;
    public static int count = 0;
    public static int countDeadPlant = 0;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
        //Debug.Log("current scene is " + SceneName);
        Pest();
        waitToHarvest = 0;
        countDeadPlant = 0;
        count = 0;
        Debug.Log("There is " + count + " left");
    }

    void Update()
    {
        Status();
        growthDuration();
        
        Debug.Log("There is " + count + " left");
    }
    public void OnMouseUp()
    {
        // GMScript.currentClick = "null";

    }
    public void OnMouseDown()
    {    
        //level1
        if (SceneName == "Level1") {
            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestChilli) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                waitForWater = 0;
                watered = "n";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(chilliPrice);
                Debug.Log("There is " + count + " left");
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestNapa) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeNapa = 0f;
                waitForWater = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(NapaPrice);
                count--;
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCK) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCK = 0f;
                waitForWater = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(CKPrice);
                count--;
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestBasil) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeBasil = 0f;
                waitForWater = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(BasilPrice);
                count--;
            }

            if ((GMScript.currentTool == "Chilli") && tools.AllowChilli != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedChilli;
                count++;
            }

            if ((GMScript.currentTool == "Napa") && tools.AllowNapa != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedNapa;
                count++;
            }

            if ((GMScript.currentTool == "ChineseKale") && tools.AllowCK != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCK;
                count++;
            }

            if ((GMScript.currentTool == "Basil") && tools.AllowBasil != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedBasil;
                count++;
            }

            if (GMScript.currentTool == "watering" && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Water");
                plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
                watered = "y";
            }

            if ((GMScript.currentTool == "pesticide") && tools.AllowPesticide != 0 && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false)) {
                SFXManager.GameSound("Spray");
                Reduce();
                pest = "n";
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == deadPlant) && (PauseMenu.GameIsPaused == false) && (Countdown.GameOver == false) && (Countdown.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                growTimeCK = 0f;
                growTimeNapa = 0f;
                growTimeBasil = 0f;
                waitForWater = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(DeadPlant);
                count--;
            }
        }

        //level2
        if (SceneName == "Level2") {
            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestChilli) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                waitForWater = 0;
                watered = "n";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(chilliPrice);
                Debug.Log("There is " + count + " left");
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestNapa) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeNapa = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(NapaPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCK) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCK = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(CKPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestBasil) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeBasil = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(BasilPrice);
                count--;
                Pest();
            }

            if ((GMScript.currentTool == "Chilli") && tools.AllowChilli != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedChilli;
                count++;
            }

            if ((GMScript.currentTool == "Napa") && tools.AllowNapa != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedNapa;
                count++;
            }

            if ((GMScript.currentTool == "ChineseKale") && tools.AllowCK != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCK;
                count++;
            }

            if ((GMScript.currentTool == "Basil") && tools.AllowBasil != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedBasil;
                count++;
            }

            if (GMScript.currentTool == "watering" && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Water");
                plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
                watered = "y";
            }

            if ((GMScript.currentTool == "pesticide") && (tools.AllowPesticide != 0) && (pest == "y") && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false)) {
                SFXManager.GameSound("Spray");
                Reduce();
                pest = "n";
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == deadPlant) && (PauseMenu.GameIsPaused == false) && (CountdownLevel2.GameOver == false) && (CountdownLevel2.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                growTimeCK = 0f;
                growTimeNapa = 0f;
                growTimeBasil = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(DeadPlant);
                Pest();
                count--;
            }
        }

        //level3
        if (SceneName == "Level3") {
            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestChilli) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                waitForWater = 0;
                watered = "y";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(chilliPrice);
                Debug.Log("There is " + count + " left");
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestNapa) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeNapa = 0f;
                waitForWater = 0;
                waitToHarvest = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(NapaPrice);
                count--;
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCK) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCK = 0f;
                waitForWater = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(CKPrice);
                count--;
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestBasil) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeBasil = 0f;
                waitForWater = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(BasilPrice);
                count--;
            }

            if ((GMScript.currentTool == "Chilli") && tools.AllowChilli != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedChilli;
                count++;
            }

            if ((GMScript.currentTool == "Napa") && tools.AllowNapa != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedNapa;
                count++;
            }

            if ((GMScript.currentTool == "ChineseKale") && tools.AllowCK != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCK;
                count++;
            }

            if ((GMScript.currentTool == "Basil") && tools.AllowBasil != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedBasil;
                count++;
            }

            if (GMScript.currentTool == "watering" && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Water");
                plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
                watered = "y";
            }

            if ((GMScript.currentTool == "pesticide") && tools.AllowPesticide != 0 && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false)) {
                SFXManager.GameSound("Spray");
                Reduce();
                pest = "n";
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == deadPlant) && (PauseMenu.GameIsPaused == false) && (CountdownLevel3.GameOver == false) && (CountdownLevel3.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                growTimeCK = 0f;
                growTimeNapa = 0f;
                growTimeBasil = 0f;
                waitToHarvest = 0;
                waitForWater = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(DeadPlant);
                count--;
            }
        }
    
        //level4
        if (SceneName == "Level4") {
            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestChilli) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                waitForWater = 0;
                watered = "n";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(chilliPrice);
                Debug.Log("There is " + count + " left");
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestNapa) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeNapa = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(NapaPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCK) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCK = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(CKPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestBasil) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeBasil = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(BasilPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestGalangal) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeGalangal = 0f;
                waitForWater = 0;
                watered = "n";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(GalangalPrice);
                Debug.Log("There is " + count + " left");
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCoriander) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCoriander = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(CorianderPrice);
                count--;
                Pest();
            }

            if ((GMScript.currentTool == "Chilli") && tools.AllowChilli != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedChilli;
                count++;
            }

            if ((GMScript.currentTool == "Napa") && tools.AllowNapa != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedNapa;
                count++;
            }

            if ((GMScript.currentTool == "ChineseKale") && tools.AllowCK != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCK;
                count++;
            }

            if ((GMScript.currentTool == "Basil") && tools.AllowBasil != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedBasil;
                count++;
            }

            if ((GMScript.currentTool == "Galangal") && tools.AllowGalangal != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedGalangal;
                count++;
            }

            if ((GMScript.currentTool == "Coriander") && tools.AllowCoriander != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCoriander;
                count++;
            }

            if ((GMScript.currentTool == "watering") && watered == "n" && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Water");
                plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
                watered = "y";
            }

            if ((GMScript.currentTool == "pesticide") && (tools.AllowPesticide != 0) && (pest == "y") && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false)) {
                SFXManager.GameSound("Spray");
                Reduce();
                pest = "n";
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == deadPlant) && (PauseMenu.GameIsPaused == false) && (CountdownLevel4.GameOver == false) && (CountdownLevel4.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                growTimeCK = 0f;
                growTimeNapa = 0f;
                growTimeBasil = 0f;
                growTimeGalangal = 0f;
                growTimeCoriander = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(DeadPlant);
                Pest();
                count--;
            }
        }
        
        //level5
        if (SceneName == "Level5") {
            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestChilli) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                waitForWater = 0;
                watered = "y";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(chilliPrice);
                Debug.Log("There is " + count + " left");
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestNapa) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeNapa = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(NapaPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCK) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCK = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(CKPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestBasil) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeBasil = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(BasilPrice);
                count--;
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestGalangal) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeGalangal = 0f;
                waitForWater = 0;
                watered = "y";
                count--;
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(GalangalPrice);
                Debug.Log("There is " + count + " left");
                Pest();
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == harvestCoriander) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeCoriander = 0f;
                waitForWater = 0;
                waitForPest = 0;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                CoinManager.instance.ChangeCoins(CorianderPrice);
                count--;
                Pest();
            }

            if ((GMScript.currentTool == "Chilli") && tools.AllowChilli != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedChilli;
                count++;
            }

            if ((GMScript.currentTool == "Napa") && tools.AllowNapa != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedNapa;
                count++;
            }

            if ((GMScript.currentTool == "ChineseKale") && tools.AllowCK != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCK;
                count++;
            }

            if ((GMScript.currentTool == "Basil") && tools.AllowBasil != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedBasil;
                count++;
            }

            if ((GMScript.currentTool == "Galangal") && tools.AllowGalangal != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedGalangal;
                count++;
            }

            if ((GMScript.currentTool == "Coriander") && tools.AllowCoriander != 0 && (GetComponent<SpriteRenderer>().sprite == noPlantObj) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Plant");
                Reduce();
                GetComponent<SpriteRenderer>().sprite = seedCoriander;
                count++;
            }

            if ((GMScript.currentTool == "watering") && watered == "n" && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Water");
                plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
                watered = "y";
            }

            if ((GMScript.currentTool == "pesticide") && (tools.AllowPesticide != 0) && (pest == "y") && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false)) {
                SFXManager.GameSound("Spray");
                Reduce();
                pest = "n";
            }

            if (GMScript.currentTool == "scythe" && (GetComponent<SpriteRenderer>().sprite == deadPlant) && (PauseMenu.GameIsPaused == false) && (CountdownLevel5.GameOver == false) && (CountdownLevel5.GameComplete == false))
            {
                SFXManager.GameSound("Harvest");
                growTimeChilli = 0f;
                growTimeCK = 0f;
                growTimeNapa = 0f;
                growTimeBasil = 0f;
                growTimeGalangal = 0f;
                growTimeCoriander = 0f;
                waitToHarvest = 0;
                waitForWater = 0;
                waitForPest = 0;
                countDeadPlant++;
                watered = "y";
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                CoinManager.instance.ChangeCoins(DeadPlant);
                Pest();
                count--;
            }
        }
    }


    public void Reduce() {

        if ((tools.AllowChilli <= tools.maxChilli) && (GMScript.currentTool == "Chilli") && tools.ChilliQuantity != 0) {
            tools.ChilliQuantity--;
            tools.AllowChilli--;
            tools.AllowClick--;
        }

        if ((tools.AllowNapa <= tools.maxNapa) && (GMScript.currentTool == "Napa") && tools.NapaQuantity != 0) {
            tools.NapaQuantity--;
            tools.AllowNapa--;
            tools.AllowClick--;
        }

        if ((tools.AllowCK <= tools.maxCK) && (GMScript.currentTool == "ChineseKale") && tools.CKQuantity != 0) {
            tools.CKQuantity--;
            tools.AllowCK--;
            tools.AllowClick--;
        }

        if ((tools.AllowBasil <= tools.maxBasil) && (GMScript.currentTool == "Basil") && tools.BasilQuantity != 0) {
            tools.BasilQuantity--;
            tools.AllowBasil--;
            tools.AllowClick--;
        }

        if ((tools.AllowCK <= tools.maxGalangal) && (GMScript.currentTool == "Galangal") && tools.GalangalQuantity != 0) {
            tools.GalangalQuantity--;
            tools.AllowGalangal--;
            tools.AllowClick--;
        }

        if ((tools.AllowCoriander <= tools.maxCoriander) && (GMScript.currentTool == "Coriander") && tools.CorianderQuantity != 0) {
            tools.CorianderQuantity--;
            tools.AllowCoriander--;
            tools.AllowClick--;
        }

        if ((tools.AllowPesticide <= tools.maxPesticide) && (GMScript.currentTool == "pesticide") && tools.pesticideQuantity != 0) {
            tools.pesticideQuantity--;
            tools.AllowPesticide--;
        }
    }

    void growthDuration()
    {
        if (SceneName == "Level1") {
            //Chilli
            if (GetComponent<SpriteRenderer>().sprite == seedChilli)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeChilli += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeChilli = 0;
                    waitForWater = 0;
                    count--;
                }
            }
            
            if (growTimeChilli > 7.5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutChilli;
                growTimeChilli += Time.deltaTime;
                    
                if (growTimeChilli > 15)
                {
                    GetComponent<SpriteRenderer>().sprite = growthChilli;
                    growTimeChilli += Time.deltaTime;

                    if (growTimeChilli > 22.5)
                    {
                        GetComponent<SpriteRenderer>().sprite = flowerChilli;
                        growTimeChilli += Time.deltaTime;

                        if (growTimeChilli > 30)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestChilli;
                        }  
                    }
                }
            }

            //Napa
            if (GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutNapa;
                growTimeNapa += Time.deltaTime;
                if (growTimeNapa > 10)
                {
                    GetComponent<SpriteRenderer>().sprite = growthNapa;
                    growTimeNapa += Time.deltaTime;
                    if (growTimeNapa > 15)
                    {
                        GetComponent<SpriteRenderer>().sprite = harvestNapa;
                    }
                }
            }
        }

        if (SceneName == "Level2") {
            //Chilli
            if (GetComponent<SpriteRenderer>().sprite == seedChilli)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeChilli += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeChilli = 0;
                    waitForWater = 0;
                    count--;
                }
            }
            
            if (growTimeChilli > 7.5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutChilli;
                growTimeChilli += Time.deltaTime;
                    
                if (growTimeChilli > 15)
                {
                    GetComponent<SpriteRenderer>().sprite = growthChilli;
                    if (pest == "n") {
                        growTimeChilli += Time.deltaTime;

                        if (growTimeChilli > 22.5)
                        {
                            GetComponent<SpriteRenderer>().sprite = flowerChilli;
                            if (pest == "n") {
                                growTimeChilli += Time.deltaTime;

                                if (growTimeChilli > 30)
                                {
                                    GetComponent<SpriteRenderer>().sprite = harvestChilli;
                                }
                            }
                            else {
                                waitForPest += Time.deltaTime;
                                if (waitForPest >= 3) {
                                    GetComponent<SpriteRenderer>().sprite = deadPlant;
                                    growTimeChilli = 0;
                                    waitForPest = 0;
                                    waitForWater = 0;
                                    watered = "n";
                                    plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                                }
                            }
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeChilli = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //Napa
            if (GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutNapa;
                growTimeNapa += Time.deltaTime;
                if (growTimeNapa > 10)
                {
                    GetComponent<SpriteRenderer>().sprite = growthNapa;
                    if (pest == "n") {
                        growTimeNapa += Time.deltaTime;
                        if (growTimeNapa > 15)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestNapa;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeNapa = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //ChineseKale
            if (GetComponent<SpriteRenderer>().sprite == seedCK)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCK += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCK = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCK > 8.3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutCK;
                growTimeCK += Time.deltaTime;
                if (growTimeCK > 16.6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthCK;
                    if (pest == "n") {
                        growTimeCK += Time.deltaTime;
                        if (growTimeCK > 25)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestCK;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeCK = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //Basil
            if (GetComponent<SpriteRenderer>().sprite == seedBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeBasil += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeBasil > 3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutBasil;
                growTimeBasil += Time.deltaTime;
                if (growTimeBasil > 6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthBasil;
                    if (pest == "n") {
                        growTimeBasil += Time.deltaTime;
                        if (growTimeBasil > 9)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestBasil;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeBasil = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }
        }

        if (SceneName == "Level3") {
            watered = "y";
            plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
            //Chilli
            if (GetComponent<SpriteRenderer>().sprite == seedChilli)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeChilli += Time.deltaTime;
                }
                else if (waitForWater >= 5) { //dead
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeChilli = 0;
                    waitForWater = 0;
                    count--;
                }
            }
            
            if (growTimeChilli > 7.5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutChilli;
                growTimeChilli += Time.deltaTime;
                    
                if (growTimeChilli > 15)
                {
                    GetComponent<SpriteRenderer>().sprite = growthChilli;
                    growTimeChilli += Time.deltaTime;

                    if (growTimeChilli > 22.5)
                    {
                        GetComponent<SpriteRenderer>().sprite = deadPlant;
                    }
                }
            }

            //Napa
            if (GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                }
                else if (waitForWater >= 5) { //dead
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutNapa;
                growTimeNapa += Time.deltaTime;
                if (growTimeNapa > 10)
                {
                    GetComponent<SpriteRenderer>().sprite = growthNapa;
                    growTimeNapa += Time.deltaTime;
                    if (growTimeNapa > 15)
                    {
                        GetComponent<SpriteRenderer>().sprite = harvestNapa;
                        waitToHarvest += Time.deltaTime;
                        if (waitToHarvest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                        }
                    }
                }
            }

            //ChineseKale
            if (GetComponent<SpriteRenderer>().sprite == seedCK)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCK += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCK = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCK > 8.3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutCK;
                growTimeCK += Time.deltaTime;
                if (growTimeCK > 16.6)
                {
                    GetComponent<SpriteRenderer>().sprite = deadPlant;
                }
            }

            //Basil
            if (GetComponent<SpriteRenderer>().sprite == seedBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeBasil += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeBasil > 3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutBasil;
                growTimeBasil += Time.deltaTime;
                if (growTimeBasil > 6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthBasil;
                    growTimeBasil += Time.deltaTime;
                    if (growTimeBasil > 9)
                    {
                        GetComponent<SpriteRenderer>().sprite = harvestBasil;
                    }
                }
            }
        }
    
        if (SceneName == "Level4") {
            //Chilli
            if (GetComponent<SpriteRenderer>().sprite == seedChilli)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeChilli += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeChilli = 0;
                    waitForWater = 0;
                    count--;
                }
            }
            
            if (growTimeChilli > 7.5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutChilli;
                growTimeChilli += Time.deltaTime;
                    
                if (growTimeChilli > 15)
                {
                    GetComponent<SpriteRenderer>().sprite = growthChilli;
                    if (pest == "n") {
                        growTimeChilli += Time.deltaTime;

                        if (growTimeChilli > 22.5)
                        {
                            GetComponent<SpriteRenderer>().sprite = flowerChilli;
                            if (pest == "n") {
                                growTimeChilli += Time.deltaTime;

                                if (growTimeChilli > 30)
                                {
                                    GetComponent<SpriteRenderer>().sprite = harvestChilli;
                                }
                            }
                            else {
                                waitForPest += Time.deltaTime;
                                if (waitForPest >= 3) {
                                    GetComponent<SpriteRenderer>().sprite = deadPlant;
                                    growTimeChilli = 0;
                                    waitForPest = 0;
                                    waitForWater = 0;
                                    watered = "n";
                                    plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                                }
                            }
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeChilli = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            Debug.Log("growth: " + growTimeBasil + " water: " + waitForWater + " water status: " + watered);
            //Napa
            if (GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5 && GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater = 0;
                growTimeNapa = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = sproutNapa;
            }

            if (GetComponent<SpriteRenderer>().sprite == sproutNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5)
            {
                GetComponent<SpriteRenderer>().sprite = growthNapa;
                if (pest == "n") {
                growTimeNapa += Time.deltaTime;
                    if (growTimeNapa > 10)
                    {
                        GetComponent<SpriteRenderer>().sprite = harvestNapa;
                    }
                }
                else {
                    waitForPest += Time.deltaTime;
                    if (waitForPest >= 3) {
                        GetComponent<SpriteRenderer>().sprite = deadPlant;
                        growTimeNapa = 0;
                        waitForPest = 0;
                        waitForWater = 0;
                        watered = "n";
                        plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                    }
                }
            }

            //ChineseKale
            if (GetComponent<SpriteRenderer>().sprite == seedCK)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCK += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCK = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCK > 8.3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutCK;
                growTimeCK += Time.deltaTime;
                if (growTimeCK > 16.6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthCK;
                    if (pest == "n") {
                        growTimeCK += Time.deltaTime;
                        if (growTimeCK > 25)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestCK;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeCK = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //Basil
            if (GetComponent<SpriteRenderer>().sprite == seedBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeBasil += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeBasil > 3 && GetComponent<SpriteRenderer>().sprite == seedBasil)
            {
                waitForWater = 0;
                growTimeBasil = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = sproutBasil;
            }

            if (GetComponent<SpriteRenderer>().sprite == sproutBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeBasil += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeBasil > 3 && GetComponent<SpriteRenderer>().sprite == sproutBasil)
            {
                waitForWater = 0;
                growTimeBasil = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = growthBasil;
            }

            if (GetComponent<SpriteRenderer>().sprite == growthBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    if (pest == "n") {
                        growTimeBasil += Time.deltaTime;
                        if (growTimeBasil > 6)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestBasil;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeBasil = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            //Galangal
            if (GetComponent<SpriteRenderer>().sprite == seedGalangal)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeGalangal += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeGalangal = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeGalangal > 6.7 && GetComponent<SpriteRenderer>().sprite == seedGalangal)
            {
                waitForWater = 0;
                growTimeGalangal = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = sproutGalangal;
            }

            if (GetComponent<SpriteRenderer>().sprite == sproutGalangal)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeGalangal += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeGalangal = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeGalangal > 7.1 && GetComponent<SpriteRenderer>().sprite == sproutGalangal)
            {
                waitForWater = 0;
                growTimeGalangal = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = growthGalangal;
            }

            if (GetComponent<SpriteRenderer>().sprite == growthGalangal)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    if (pest == "n") {
                        growTimeGalangal += Time.deltaTime;
                        if (growTimeGalangal > 6.6)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestGalangal;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeGalangal = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeGalangal = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            //Coriander
            if (GetComponent<SpriteRenderer>().sprite == seedCoriander)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCoriander += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCoriander = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCoriander > 3.3 && GetComponent<SpriteRenderer>().sprite == seedCoriander)
            {
                waitForWater = 0;
                growTimeCoriander = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = sproutCoriander;
            }

            if (GetComponent<SpriteRenderer>().sprite == sproutCoriander)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCoriander += Time.deltaTime;
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCoriander = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCoriander > 3.3 && GetComponent<SpriteRenderer>().sprite == sproutCoriander)
            {
                waitForWater = 0;
                growTimeCoriander = 0;
                plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                watered = "n";
                GetComponent<SpriteRenderer>().sprite = growthCoriander;
            }

            if (GetComponent<SpriteRenderer>().sprite == growthCoriander)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    if (pest == "n") {
                        growTimeCoriander += Time.deltaTime;
                        if (growTimeCoriander > 5.4)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestCoriander;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeCoriander = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                    waitForWater = 0;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCoriander = 0;
                    waitForWater = 0;
                    count--;
                }
            }
        }
    
        if (SceneName == "Level5") {
            watered = "y";
            plot.GetComponent<SpriteRenderer>().sprite = waterPlot;
            //Chilli
            if (GetComponent<SpriteRenderer>().sprite == seedChilli)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeChilli += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeChilli = 0;
                    waitForWater = 0;
                    count--;
                }
            }
            
            if (growTimeChilli > 7.5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutChilli;
                growTimeChilli += Time.deltaTime;
                    
                if (growTimeChilli > 15)
                {
                    GetComponent<SpriteRenderer>().sprite = growthChilli;
                    growTimeChilli += Time.deltaTime;

                    if (growTimeChilli > 22.5)
                    {
                        GetComponent<SpriteRenderer>().sprite = deadPlant;
                    }
                }
            }

            //Napa
            if (GetComponent<SpriteRenderer>().sprite == seedNapa)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeNapa += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeNapa = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeNapa > 5)
            {
                GetComponent<SpriteRenderer>().sprite = sproutNapa;
                growTimeNapa += Time.deltaTime;
                if (growTimeNapa > 10)
                {
                    GetComponent<SpriteRenderer>().sprite = growthNapa;
                    if (pest == "n") {
                        growTimeNapa += Time.deltaTime;
                        if (growTimeNapa > 15)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestNapa;
                            waitToHarvest += Time.deltaTime;
                            if (waitToHarvest >= 3) {
                                GetComponent<SpriteRenderer>().sprite = deadPlant;
                                waitToHarvest = 0;
                            }
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeNapa = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //ChineseKale
            if (GetComponent<SpriteRenderer>().sprite == seedCK)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCK += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCK = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCK > 8.3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutCK;
                growTimeCK += Time.deltaTime;
                if (growTimeCK > 16.6)
                {
                    GetComponent<SpriteRenderer>().sprite = deadPlant;
                }
            }

            //Basil
            if (GetComponent<SpriteRenderer>().sprite == seedBasil)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeBasil += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeBasil = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeBasil > 3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutBasil;
                growTimeBasil += Time.deltaTime;
                if (growTimeBasil > 6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthBasil;
                    if (pest == "n") {
                        growTimeBasil += Time.deltaTime;
                        if (growTimeBasil > 9)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestBasil;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeBasil = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }
            //Galangal
            if (GetComponent<SpriteRenderer>().sprite == seedGalangal)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeGalangal += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeGalangal = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeGalangal > 6.7)
            {
                GetComponent<SpriteRenderer>().sprite = sproutGalangal;
                growTimeGalangal += Time.deltaTime;
                if (growTimeGalangal > 13.4)
                {
                    GetComponent<SpriteRenderer>().sprite = growthGalangal;
                    if (pest == "n") {
                        growTimeGalangal += Time.deltaTime;
                        if (growTimeGalangal > 20)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestGalangal;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeGalangal = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }

            //Coriander
            if (GetComponent<SpriteRenderer>().sprite == seedCoriander)
            {
                waitForWater += Time.deltaTime;
                if (watered == "y") {
                    growTimeCoriander += Time.deltaTime;
                }
                else if (waitForWater >= 5) {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
                    growTimeCoriander = 0;
                    waitForWater = 0;
                    count--;
                }
            }

            if (growTimeCoriander > 3.3)
            {
                GetComponent<SpriteRenderer>().sprite = sproutCoriander;
                growTimeCoriander += Time.deltaTime;
                if (growTimeCoriander > 6.6)
                {
                    GetComponent<SpriteRenderer>().sprite = growthCoriander;
                    if (pest == "n") {
                        growTimeCoriander += Time.deltaTime;
                        if (growTimeCoriander > 10)
                        {
                            GetComponent<SpriteRenderer>().sprite = harvestCoriander;
                        }
                    }
                    else {
                        waitForPest += Time.deltaTime;
                        if (waitForPest >= 3) {
                            GetComponent<SpriteRenderer>().sprite = deadPlant;
                            growTimeCoriander = 0;
                            waitForPest = 0;
                            waitForWater = 0;
                            watered = "n";
                            plot.GetComponent<SpriteRenderer>().sprite = UnwaterPlot;
                        }
                    }
                }
            }
        }
    }

    public void CheckDeadPlant() {
        if (GetComponent<SpriteRenderer>().sprite == deadPlant) {
            countDeadPlant++;
        }
    }

    public void Pest() {
        Rand = Random.Range(0, 2);
        if (Rand == 1) {
            pest = "y";
        }
        else {
            pest = "n";
        }
    }

    public void Status() { //give status of plants
        if ((GetComponent<SpriteRenderer>().sprite != noPlantObj && GetComponent<SpriteRenderer>().sprite != deadPlant) && watered == "n") { //need a water
            status.GetComponent<SpriteRenderer>().sprite = StatusNeedWater;
        }
        else if ((GetComponent<SpriteRenderer>().sprite == seedChilli || GetComponent<SpriteRenderer>().sprite == seedNapa || GetComponent<SpriteRenderer>().sprite == seedCK || GetComponent<SpriteRenderer>().sprite == seedBasil || GetComponent<SpriteRenderer>().sprite == seedGalangal || GetComponent<SpriteRenderer>().sprite == seedCoriander) && watered == "y" && GetComponent<SpriteRenderer>().sprite != noPlantObj) { //happy to be watered
            status.GetComponent<SpriteRenderer>().sprite = StatusLove;
        }
        else if ((GetComponent<SpriteRenderer>().sprite == harvestChilli || GetComponent<SpriteRenderer>().sprite == harvestNapa || GetComponent<SpriteRenderer>().sprite == harvestCK || GetComponent<SpriteRenderer>().sprite == harvestBasil || GetComponent<SpriteRenderer>().sprite == harvestGalangal || GetComponent<SpriteRenderer>().sprite == harvestCoriander) && GetComponent<SpriteRenderer>().sprite != noPlantObj) { //ready to harvest
            status.GetComponent<SpriteRenderer>().sprite = StatusHarvest;
        }
        else if ((GetComponent<SpriteRenderer>().sprite == growthChilli || GetComponent<SpriteRenderer>().sprite == flowerChilli || GetComponent<SpriteRenderer>().sprite == growthNapa || GetComponent<SpriteRenderer>().sprite == growthCK || GetComponent<SpriteRenderer>().sprite == growthBasil || GetComponent<SpriteRenderer>().sprite == growthGalangal || GetComponent<SpriteRenderer>().sprite == growthCoriander) && (pest == "y") && GetComponent<SpriteRenderer>().sprite != noPlantObj && (SceneName == "Level2" || SceneName == "Level4" || SceneName == "Level5")) {
            status.GetComponent<SpriteRenderer>().sprite = StatusPest;
        }
        else {
            status.GetComponent<SpriteRenderer>().sprite = noObject;
        }
    }
}
