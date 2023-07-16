using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAmmoPickUp1 : MonoBehaviour
{
    public GameObject AutoAmmoDisplayBox;
    public AudioSource ammoPickUp;
    void OnTriggerEnter()
    {
        //AutoAmmoDisplayBox.SetActive(true);
        ammoPickUp.Play();
        SchmeisGlobalAmmo1.autoAmmoCount += 30;
        gameObject.SetActive(false);
    }
}
