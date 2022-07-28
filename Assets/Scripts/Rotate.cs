using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Quaternion targetRotation;
    public GameObject Spotlight;
    public float speed;

    [HideInInspector]
    public int hasSoundPlayed = 0;
    [HideInInspector]
    public int videoToPlay = 0;

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        //Shut down SPOTLIGHT Light and reset eventTriggered
        this.GetComponent<Coin>().eventTriggered = false;
        Spotlight.GetComponent<Light>().enabled = false;
        if (hasSoundPlayed == 0){
            SoundManager.Instance.PlaySpotlightOff();
            hasSoundPlayed++;
            videoToPlay++;
        }
        

        //Set Original Rotation
        Quaternion newQuaternion = new Quaternion();
        newQuaternion.Set(90, 0, 0,1);
        transform.rotation = newQuaternion;
        transform.Rotate(-88.727f,0f,0f);

        //Disable Component
        this.enabled = false;
    }

    void Update()
    { 
        //Check if the event is Triggered, if not, deactivate component
        if(this.GetComponent<Coin>().eventTriggered){
            //Rotate coin if not rotated around 180º, else, activate deactivation coroutine
            if (Quaternion.Angle(transform.rotation, targetRotation) >= 90.05f){
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(90, 180, 0), Time.deltaTime * speed);
            }else{
                StartCoroutine(Wait());
            }
        }else{
            this.enabled = false;
        }
        
    }

}
