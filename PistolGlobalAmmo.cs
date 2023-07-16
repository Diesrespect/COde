using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PistolGlobalAmmo : MonoBehaviour
{

    public static int pistAmmoCount;
    public GameObject pistAmmoDisplay;
    public int internalAmmo;

   

    void Update()
    {
        internalAmmo = pistAmmoCount;
        pistAmmoDisplay.GetComponent<Text>().text = "" + pistAmmoCount;
    }
}
