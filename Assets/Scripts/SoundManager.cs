using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; 

    public AudioClip SpotlightOn; 
    public AudioClip SpotlightOff; 
    public AudioClip CoinHover; 
    public AudioClip CoinFlipped; 
    public AudioClip ScreenShutdown; 

    private Vector3 cameraPosition; 

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this; // 1
        cameraPosition = Camera.main.transform.position; // 2
    }

    private void PlaySound(AudioClip clip) 
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition); 
    }
    public void PlaySpotlightOn()
    {
        PlaySound(SpotlightOn);
    }
    public void PlaySpotlightOff()
    {
        PlaySound(SpotlightOff);
    }
    public void PlayCoinFlipped()
    {
        PlaySound(CoinFlipped);
    }
    public void PlayScreenShutdown()
    {
        PlaySound(ScreenShutdown);
    }
}
