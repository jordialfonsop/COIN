using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameObject CoinText;
    public GameObject PetTheDogText;
    public GameObject Spotlight;
    public GameObject Coin;

    public GameObject ScreenNPart1;
    public GameObject ScreenNPart2;
    public GameObject ScreenNPart3;
    public GameObject ScreenS;
    public GameObject ScreenW;
    public GameObject ScreenE;

    public GameObject CoinHoverMusic;

    private bool SpotNPart1Played = false;
    private bool SpotNPart2Played = false;
    private bool SpotNPart3Played = false;
    private bool SpotSPlayed = false;
    private bool DogWPlayed = false;
    private bool DronesEPlayed = false;

    private bool SpotNPart1Off = false;
    private bool SpotNPart2Off = false;
    private bool SpotNPart3Off = false;
    private bool SpotSOff = false;
    private bool DogWOff = false;
    private bool DronesEOff = false;

    private bool lastCoinDisplayed = false;
    private bool petTheDogDisplayed = false;

    void SpotlightUp(){
        Spotlight.GetComponent<Light>().enabled = true;
        SoundManager.Instance.PlaySpotlightOn();
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PlayGame());
    }

    IEnumerator StartGame(){

        yield return new WaitForSeconds(2);

        CoinText.SetActive(true);

        yield return new WaitForSeconds(3);

        CoinText.SetActive(false);

        yield return new WaitForSeconds(2);

        Coin.SetActive(true);
        SpotlightUp();
    }

    IEnumerator PlayGame(){

        if (Coin.GetComponent<Rotate>().videoToPlay == 1 && !SpotNPart1Played){
            SpotNPart1Played = true;
            CoinHoverMusic.SetActive(false);
            Coin.SetActive(false);
            yield return new WaitForSeconds(3);
            ScreenNPart1.SetActive(true);
            
        }

        if (SpotNPart1Played){

            yield return new WaitForSeconds(40);

            if (!DogWPlayed){
                DogWPlayed = true;
                ScreenW.SetActive(true);    
            }

            yield return new WaitForSeconds(9);
            if(!SpotNPart1Off){
                SpotNPart1Off = true;
                SoundManager.Instance.PlayScreenShutdown();
                ScreenNPart1.SetActive(false);
            }  

            if(DogWPlayed){

                yield return new WaitForSeconds(30);

                if (!DronesEPlayed){
                    DronesEPlayed = true;
                    ScreenE.SetActive(true);    
                }

                if (DronesEPlayed){

                    yield return new WaitForSeconds(20);

                    if (!SpotNPart2Played){
                        SpotNPart2Played = true;
                        ScreenNPart2.SetActive(true);    
                    }

                    if (SpotNPart2Played){
                        yield return new WaitForSeconds(8);
                        if(!SpotNPart2Off && !DogWOff && !DronesEOff){
                            SpotNPart2Off = true;
                            DogWOff = true;
                            DronesEOff = true;
                            SoundManager.Instance.PlayScreenShutdown();
                            ScreenNPart2.SetActive(false); 
                            yield return new WaitForSeconds(0.2f);
                            SoundManager.Instance.PlayScreenShutdown();
                            ScreenE.SetActive(false);
                            yield return new WaitForSeconds(0.2f);
                            SoundManager.Instance.PlayScreenShutdown();
                            ScreenW.SetActive(false);
                        } 
                    }
                }
            }
        }

        if(SpotNPart1Played && SpotNPart2Played && DronesEPlayed && DogWPlayed && !lastCoinDisplayed){
            lastCoinDisplayed = true;
            if (!petTheDogDisplayed){
                petTheDogDisplayed = true;

                yield return new WaitForSeconds(3);
                CoinHoverMusic.SetActive(true);
                yield return new WaitForSeconds(2);
                PetTheDogText.SetActive(true);
                yield return new WaitForSeconds(3);
                PetTheDogText.SetActive(false);
                yield return new WaitForSeconds(2);

                Coin.SetActive(true);
                SpotlightUp();
            }

        }

        if (Coin.GetComponent<Rotate>().videoToPlay == 2 && !SpotSPlayed){
            SpotSPlayed = true;
            CoinHoverMusic.SetActive(false);
            Coin.SetActive(false);
            yield return new WaitForSeconds(3);
            ScreenS.SetActive(true);
        }
        if (SpotSPlayed){
            CoinHoverMusic.SetActive(false);
            yield return new WaitForSeconds(40);

            if (!SpotNPart3Played){
                SpotNPart3Played = true;
                ScreenNPart3.SetActive(true);    
            }

            if(SpotNPart3Played){

                yield return new WaitForSeconds(15);
                if(!SpotNPart3Off && !SpotSOff){
                    SpotNPart3Off = true;
                    SpotSOff = true;
                    SoundManager.Instance.PlayScreenShutdown();
                    ScreenNPart3.SetActive(false); 
                    yield return new WaitForSeconds(0.2f);
                    SoundManager.Instance.PlayScreenShutdown();
                    ScreenS.SetActive(false);
                    yield return new WaitForSeconds(3);
                    CoinText.SetActive(true);
                    yield return new WaitForSeconds(3);
                    CoinText.SetActive(false);
                    yield return new WaitForSeconds(3);
                    Application.Quit();
                } 
            }
        }

        
        
    }
}
