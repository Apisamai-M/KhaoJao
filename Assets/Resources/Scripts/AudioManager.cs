using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //sound clip
    public AudioClip Bark;
    public AudioClip Whimper;
    public AudioClip Buy;
    public AudioClip Discard;
    //audio obj
    private AudioSource audioSrc;
    
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySound(string audioName)
    {
        switch(audioName) {
            case "Bark" :
                audioSrc.clip = Bark;
                break;
            case "Whimper" :
                audioSrc.clip = Whimper;
                break;
        }
        audioSrc.Play();
    }

    public void ShoppingSound(string audioName) {
        switch(audioName) {
            case "Buy" :
                audioSrc.clip = Buy;
                break;
            case "Discard" :
                audioSrc.clip = Discard;
                break;
        }
        audioSrc.Play();
    }
}
