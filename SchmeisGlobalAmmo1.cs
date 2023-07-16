using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchmeisGlobalAmmo1 : MonoBehaviour
{

    public static int autoAmmoCount;
    public GameObject autoAmmoDisplay;
    public int internalAmmo;

    void Update()
    {
        //internalAmmo = autoAmmoCount;
        autoAmmoDisplay.GetComponent<Text>().text = "" + autoAmmoCount;
    }
}
