using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = GMScript.currentPlant.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseP = Input.mousePosition;
        mouseP.z = transform.position.z - Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(mouseP);

        if (GMScript.currentPlant == null)
            Destroy(gameObject);
    }
}
