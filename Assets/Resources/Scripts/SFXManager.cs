using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static AudioClip plantSound;
    public static AudioClip waterSound;
    public static AudioClip harvestSound;
    public static AudioClip spraySound;
    public static AudioClip WinSound;
    public static AudioClip GameOverSound;
    //audio obj
    static AudioSource audioSrc;

    void Start()
    {
        plantSound = Resources.Load<AudioClip>("Plant");
        waterSound = Resources.Load<AudioClip>("Water");
        harvestSound = Resources.Load<AudioClip>("Harvest");
        spraySound = Resources.Load<AudioClip>("Spray");
        WinSound = Resources.Load<AudioClip>("Win");
        GameOverSound = Resources.Load<AudioClip>("GameOver");
        
        audioSrc = GetComponent<AudioSource>();
    }

    public static void GameSound(string audioName) {
        switch(audioName) {
            case "Plant" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(plantSound);
                break;
            case "Water" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(waterSound);
                break;
            case "Harvest" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(harvestSound);
                break;
            case "Spray" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(spraySound);
                break;
            case "Win" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(WinSound);
                break;
            case "GameOver" :
                audioSrc.GetComponent<AudioSource>().PlayOneShot(GameOverSound);
                break;
        }
    }
}
