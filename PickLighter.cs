using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickLighter : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject LighterIstrText;
    public GameObject FakeLighter;
    public GameObject RealLighter;
    
    public GameObject ExtraCross;
    
    public AudioSource pistolPickUp;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "pick up the flashlight";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                //ActionDisplay.SetActive(false);
                //ActionText.SetActive(false);
                ActionText.GetComponent<Text>().text = "";
                FakeLighter.SetActive(false);
                pistolPickUp.Play();
                RealLighter.SetActive(true);
                ExtraCross.SetActive(false);
                StartCoroutine(FlashLightInstruction());
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

    IEnumerator FlashLightInstruction()
    {
        
        LighterIstrText.SetActive(true);
        LighterIstrText.GetComponent<Text>().text = "press L to turn on the flashlight";
        yield return new WaitForSeconds(2f);
        LighterIstrText.SetActive(false);
    }
}

