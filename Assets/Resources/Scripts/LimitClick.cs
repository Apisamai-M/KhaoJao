using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LimitClick : MonoBehaviour
{
    public Text Quantity;
    public int Id;
    public int newQuantity;
    public int maxClick = 0;
    public int AllowClick = 0;

    private void Awake()
    {
        if (Id == 1) {
            maxClick = ButtonInfo.Item1;
            AllowClick = ButtonInfo.Item1;
        }
        if (Id == 2) {
            maxClick = ButtonInfo.Item2;
            AllowClick = ButtonInfo.Item2;
        }
        if (Id == 3) {
            maxClick = ButtonInfo.Item3;
            AllowClick = ButtonInfo.Item3;
        }
        if (Id == 4) {
            maxClick = ButtonInfo.Item4;
            AllowClick = ButtonInfo.Item4;
        }
    }
    private void Start()
    {
        if (Id == 1) {
            newQuantity = ButtonInfo.Item1;
            Quantity.text = newQuantity.ToString();
        }
        if (Id == 2) {
            newQuantity = ButtonInfo.Item2;
            Quantity.text = newQuantity.ToString();
        }
        if (Id == 3) {
            newQuantity = ButtonInfo.Item3;
            Quantity.text = newQuantity.ToString();
        }
        if (Id == 4) {
            newQuantity = ButtonInfo.Item4;
            Quantity.text = newQuantity.ToString();
        }
    }
    void OnMouseDown()
    {
        Reduce();
    }

    public void Reduce() {
        if (Id == 1) {
            if (AllowClick <= maxClick && newQuantity != 0) {
                newQuantity -= 1;
                Quantity.text = newQuantity.ToString();
                AllowClick--;
                // Debug.Log(AllowClick + " " + maxClick + " " + newQuantity);
            }
        }
        if (Id == 2) {
            if (AllowClick <= maxClick && newQuantity != 0) {
                newQuantity -= 1;
                Quantity.text = newQuantity.ToString();
                AllowClick--;
                // Debug.Log(AllowClick + " " + maxClick + " " + newQuantity);
            }
        }
        if (Id == 3) {
            if (AllowClick <= maxClick && newQuantity != 0) {
                newQuantity -= 1;
                Quantity.text = newQuantity.ToString();
                AllowClick--;
                // Debug.Log(AllowClick + " " + maxClick + " " + newQuantity);
            }
        }
        if (Id == 4) {
            if (AllowClick <= maxClick && newQuantity != 0) {
                newQuantity -= 1;
                Quantity.text = newQuantity.ToString();
                AllowClick--;
                // Debug.Log(AllowClick + " " + maxClick + " " + newQuantity);
            }
        }
    } 
}
