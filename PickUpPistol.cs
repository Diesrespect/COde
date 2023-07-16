using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpPistol : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakePistol;
    public GameObject RealPistol;
    public GameObject GuideArrow;
    public GameObject ExtraCross;
    public GameObject JumpscareDoorTrigger;
    public AudioSource pistolPickUp;
    public GameObject PistTrigger;

    void Update()
    {
        TheDistance = PlayerCast1sc.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        Debug.Log("dist: " + TheDistance);

        if(TheDistance <= 3)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "pick up the gun";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 3)
            {
                PistTrigger.SetActive(false);
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                FakePistol.SetActive(false);
                pistolPickUp.Play();
                RealPistol.SetActive(true);
                ExtraCross.SetActive(false);
                GuideArrow.SetActive(false);
                JumpscareDoorTrigger.SetActive(true);
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
