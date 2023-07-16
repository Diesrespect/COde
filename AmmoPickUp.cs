using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public GameObject pistolAmmoDisplayBox;
    public AudioSource ammoPickUp;
    void OnTriggerEnter()
    {
        //pistolAmmoDisplayBox.SetActive(true);
        ammoPickUp.Play();
        PistolGlobalAmmo.pistAmmoCount += 8;
        gameObject.SetActive(false);
    }
}
