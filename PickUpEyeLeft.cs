using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickUpEyeLeft : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject theLeftEye;
    public GameObject halfFadeDisplay;
    public AudioSource pickedPaper;

    //public GameObject fakeWall;
    //public GameObject realWall;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if(TheDistance <= 2)
        {

            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "pick up an object";
            ActionDisplay.SetActive(true); 
            ActionText.SetActive(true);
            
        }

        if(Input.GetButtonDown("Action"))
        {
            if(TheDistance <= 2)
            {
                pickedPaper.Play();
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                theLeftEye.SetActive(false);
                GlobalInvertory.leftEye = true;
                StartCoroutine(ShowingTheEye());
            }
        }
    }

    IEnumerator ShowingTheEye()
    {
        //fakeWall.SetActive(false);
        //realWall.SetActive(true);
        halfFadeDisplay.SetActive(true);
        yield return new WaitForSeconds(3);
        halfFadeDisplay.SetActive(false);
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

}
