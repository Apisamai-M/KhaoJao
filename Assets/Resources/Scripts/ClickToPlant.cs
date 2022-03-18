using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickToPlant : MonoBehaviour
{
    public GameObject Acorn;
    void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            spawnSeed();
        }
    }

    void spawnSeed() {
        Instantiate(Acorn, new Vector2(0,0), Quaternion.identity);
    }
}
