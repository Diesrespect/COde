using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MG_Enter : MonoBehaviour
{

    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public GameObject CameraSwitching;




    private void OnTriggerEnter(Collider other)
    {

        CameraSwitching.SetActive(true);

    }

    private void OnTriggerExit(Collider other)
    {
        CameraSwitching.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }



}
