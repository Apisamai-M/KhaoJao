using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceTxt;
    public Text QuantityTxt;
    public GameObject ShopManager;

    public static int Item1;
    public static int Item2;
    public static int Item3;
    public static int Item4;
    public static int Item5;
    public static int Item6;
    public static int Item7;
    
    void Update()
    {
        PriceTxt.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
        Item1 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 1];
        Item2 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 2];
        Item3 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 3];
        Item4 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 4];
        Item5 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 5];
        Item6 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 6];
        Item7 = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, 7];
    }
}
