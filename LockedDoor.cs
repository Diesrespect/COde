using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LockedDoor : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource closedDoor;
    public GameObject firstKeyDoor;
    public AudioSource CreakySound;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "open the door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(DoorReset());
            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        if(GlobalInvertory.firstDoorKey == false)
        {
            closedDoor.Play();
            yield return new WaitForSeconds(1);
            this.GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            firstKeyDoor.GetComponent<Animator>().Play("FirstDoorKeyAnim");
            CreakySound.Play();
            yield return new WaitForSeconds(0.7f);
            this.GetComponent<BoxCollider>().enabled = false;
        }
        
    }
}
