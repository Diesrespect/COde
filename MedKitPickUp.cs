using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKitPickUp : MonoBehaviour

{
    //public GameObject MedKitBox;
    public AudioSource MedKitPick;
    public static int healthGain = 20;
    void OnTriggerEnter()
    {
        
        if(GlobalHealth.currentHealth + healthGain >= 100 && GlobalHealth.currentHealth < 100)
        {
            GlobalHealth.currentHealth = 100;
            MedKitPick.Play();
            gameObject.SetActive(false);
        }
        else if(GlobalHealth.currentHealth + healthGain < 100)
        {
            GlobalHealth.currentHealth += healthGain;
            MedKitPick.Play();
            gameObject.SetActive(false);
        }
       
    }
}

