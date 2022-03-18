using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public static int SumCoin = 100;

    public TextMeshProUGUI text;
    public TextMeshProUGUI textComplete;
    public static int coins;
    // Start is called before the first frame update
    void Awake()
    {
        coins = 0;
    }
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
  

    public void ChangeCoins(int plant_price) 
    {
        coins += plant_price;
        text.text = "x" + coins.ToString();
    }
  

 
}
