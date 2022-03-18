using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBackgroundMusic : MonoBehaviour
{
    void Start()
    {
        backgroundMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
    }
}
