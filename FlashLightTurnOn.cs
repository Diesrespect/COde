using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightTurnOn : MonoBehaviour
{
    public GameObject Lighter;
    public AudioSource TurningOn;
    public GameObject displayOn;
    public GameObject displayOff;

    private void Start()
    {
        if (Lighter.activeInHierarchy == true)
        {
            displayOn.SetActive(true);
            displayOff.SetActive(false);
        }
        else
        {
            displayOn.SetActive(false);
            displayOff.SetActive(true);
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Light"))
        {
            if(Lighter.activeInHierarchy == true)
            {
                displayOn.SetActive(false);
                displayOff.SetActive(true);
                Lighter.SetActive(false);
                TurningOn.Play();
            }
            else if(Lighter.activeInHierarchy == false)
            {
                displayOn.SetActive(true);
                displayOff.SetActive(false);
                Lighter.SetActive(true);
                TurningOn.Play();
            }
        }
    }
}
