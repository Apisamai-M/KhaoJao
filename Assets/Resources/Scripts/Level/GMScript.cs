using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{
    public static string currentTool = "none";
    public static string currentClick = "none";
  

    public bool Watering_ScythrEnable;
    public static GameObject currentPlant, currentSeed;
    // Start is called before the first frame update
    void Start()
    {
        Watering_ScythrEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
