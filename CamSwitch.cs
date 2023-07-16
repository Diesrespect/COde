using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class CamSwitch : MonoBehaviour
{
    public machineGUN machGun;
    public FireMG gunFire;
    public Camera playerCam;
    public Camera weaponCam;
    public Camera machinegunCam;

    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;

    public GameObject weapons;

    public GameObject notWalkWall;
    public GameObject thePlayer;
   

    // Start is called before the first frame update
    void Start()
    {

        gunFire.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCam.enabled == true)
        {
            
            ActionText.GetComponent<Text>().text = "Стати за кулемет";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            //FireMG.IsFiring = true;

            if (Input.GetButtonDown("Action"))
            {
                playerCam.enabled = false;
                machinegunCam.enabled = true;
                machGun._isEnable = true;
                weaponCam.enabled = false;
                weapons.SetActive(false);
                gunFire.enabled = true;
                
                notWalkWall.SetActive(true);

                thePlayer.GetComponent<FirstPersonController>().enabled = false;

            }
        }
        else if(machinegunCam.enabled == true)
        {
           // FireMG.IsFiring = false;
            ActionText.GetComponent<Text>().text = "Відійти від кулемета";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);

            if (Input.GetButtonDown("Action"))
            {
                playerCam.enabled = true;
                machinegunCam.enabled = false;
                machGun._isEnable = false;
                weaponCam.enabled = true;
                weapons.SetActive(true);
                gunFire.enabled = false;
                notWalkWall.SetActive(false);
                thePlayer.GetComponent<FirstPersonController>().enabled = true;

            }
        }
        

        
    }
}
