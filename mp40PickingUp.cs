using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mp40PickingUp : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject FakeMp40;
    public GameObject RealMp40;
   
    public GameObject ExtraCross;
    public GameObject weaponHolder;
    public AudioSource mp40lPickUp;

    public GameObject spotLight;
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "pick up the gun";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);

        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                weaponHolder.GetComponent<WeaponSwitching>().enabled = true;
                mp40lPickUp.Play();
                FakeMp40.SetActive(false);
                //RealMp40.SetActive(true);
                ExtraCross.SetActive(false);
                spotLight.SetActive(false);
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
