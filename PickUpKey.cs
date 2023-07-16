using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpKey : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject theKey;
    public AudioSource pickedKey;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 3)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "pick up the key";
            ActionDisplay.SetActive(true); 
            ActionText.SetActive(true);
            
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 5)
            {
                pickedKey.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                theKey.SetActive(false);
                GlobalInvertory.firstDoorKey = true;
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

}
