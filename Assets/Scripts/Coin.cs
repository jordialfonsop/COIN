using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [HideInInspector]
    public bool canBeFlipped = false;

    [HideInInspector]
    public bool eventTriggered = false;

    public GameObject Spotlight;

    // Update is called once per frame
    void Update()
    {
        if (Spotlight.GetComponent<Light>().enabled == true){
            if (this.GetComponent<Rotate>().enabled == false){
                if(!eventTriggered){
                    canBeFlipped = true;
                }else{
                    canBeFlipped = false;
                } 
            }else{
                canBeFlipped = false;
            }
        }else{
            canBeFlipped = false;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Hand" && canBeFlipped)
        {
            eventTriggered = true;
            this.GetComponent<Rotate>().enabled = true;
            this.GetComponent<Rotate>().hasSoundPlayed = 0;
            SoundManager.Instance.PlayCoinFlipped();
        }
    }
}
