using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManagerScript : MonoBehaviour
{
    public static ShopManagerScript instance;
    public int[,] shopItems = new int[8, 8];
    public Text CoinsTxt;
    public Scene currentScene;
    public string SceneName;
    public static bool minigamecomplete;
    //public static bool Getcoin;


    public int canreward;
    public static int Allbuy;
    public  int notplayyet = 1;

    void Awake()
    {
        instance = this;
        Allbuy = 0;
    }
    void Start()
    {
        
        Debug.Log(CoinManager.SumCoin);
        Debug.Log(CoinManager.coins);


        currentScene = SceneManager.GetActiveScene();
        SceneName = currentScene.name;
            //Item ID
        
            shopItems[1, 1] = 1; //item1 Chilli
            shopItems[1, 2] = 2; //item2 Chinese Kale
            shopItems[1, 3] = 3; //item3 Napa Cabbage
            shopItems[1, 4] = 4; //item4 Holy Basil
            shopItems[1, 5] = 5; //pesticide
            shopItems[1, 6] = 6; //galangal
            shopItems[1, 7] = 7; //coriander

            //Price
            shopItems[2, 1] = 5;
            shopItems[2, 2] = 5;
            shopItems[2, 3] = 15;
            shopItems[2, 4] = 6;
            shopItems[2, 5] = 5;
            shopItems[2, 6] = 7;
            shopItems[2, 7] = 8;

            //Quantity
            shopItems[3, 1] = 0;
            shopItems[3, 2] = 0;
            shopItems[3, 3] = 0;
            shopItems[3, 4] = 0;
            shopItems[3, 5] = 0;
            shopItems[3, 6] = 0;
            shopItems[3, 7] = 0;

        
            Debug.Log(minigamecomplete);


        if (minigamecomplete == true)
        {
            if (SceneName == "ShopWindowLevel4")
            {
                QuizManagerGame3.instance.getreward();
                Debug.Log("canreward = " + canreward);
                //Getcoin = false;

            }
            if (SceneName == "ShopWindowLevel5")
            {
                QuizManager.instance.getreward();
                //Getcoin = false;

            }
        }

    if(BtnControl.back == false)
    {
        CoinManager.SumCoin += CoinManager.coins;
        CoinManager.coins = 0;

    }
        CoinsTxt.text = "Coins: " + CoinManager.SumCoin.ToString();

    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (CoinManager.SumCoin >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        { //to check there are enough coins to buy the item
            //minus the coins with the item's price
            CoinManager.SumCoin -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            Allbuy += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //increase quantity of buying items
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            //update coins 
            CoinsTxt.text = "Coins: " + CoinManager.SumCoin.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }

    public void UnBuy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Debug.Log(minigamecomplete);
        if (minigamecomplete == true)
        {
            if (shopItems[3, 5] == canreward)
            {
                Debug.Log(canreward);
                if (ButtonRef.GetComponent<ButtonInfo>().ItemID != 5)
                {
                    if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] != 0)
                    {
                        CoinManager.SumCoin += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                        Allbuy -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                        //increase quantity of buying items
                        shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
                        //update coins 
                        CoinsTxt.text = "Coins: " + CoinManager.SumCoin.ToString();
                        ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
                    }
                }
            }
            else
            {
                if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] != 0)
                {
                    CoinManager.SumCoin += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                    Allbuy -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                    //increase quantity of buying items
                    shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
                    //update coins 
                    CoinsTxt.text = "Coins: " + CoinManager.SumCoin.ToString();
                    ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
                }
            }

        }
        else
        {
            if (shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID] != 0)
            {
                CoinManager.SumCoin += shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                Allbuy -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
                //increase quantity of buying items
                shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]--;
                //update coins 
                CoinsTxt.text = "Coins: " + CoinManager.SumCoin.ToString();
                ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            }
            Debug.Log("> reward");
        }


    }


    public void morepesticide(int reward)
    {
        if (reward == 2)
        {
            canreward = reward;
            // if(Getcoin == true){
            //     CoinManager.SumCoin += 50;
            // }
            for (int i = 0; i < reward; i++)
            {
                Debug.Log(shopItems[3, 5]);
                shopItems[3, 5]++;

            }
        }
        if (reward == 1)
        {
            canreward = reward;
            //  if(Getcoin == true){
            //     CoinManager.SumCoin += 25;
            // }
            for (int i = 0; i < reward; i++)
            {
                Debug.Log(shopItems[3, 5]);
                shopItems[3, 5]++;

            }
        }
    }

}
