using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seedQuantity : MonoBehaviour
{
    public  Text Quantity;
    public int Id;


    void Update()
    {

        if (Id == 1) {
            Quantity.text = (tools.ChilliQuantity).ToString();
        }
        if (Id == 2) {
            Quantity.text = (tools.CKQuantity).ToString();
        }
        if (Id == 3) {
            Quantity.text = (tools.NapaQuantity).ToString();
        }
        if (Id == 4) {
            Quantity.text = (tools.BasilQuantity).ToString();
        }
        if (Id == 5) {
            Quantity.text = (tools.pesticideQuantity).ToString();
        }
        if (Id == 6) {
            Quantity.text = (tools.GalangalQuantity).ToString();
        }
        if (Id == 7) {
            Quantity.text = (tools.CorianderQuantity).ToString();           
        }


    }


    
} 