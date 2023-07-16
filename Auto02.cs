using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto02 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GlobalHealth.currentHealth = 100;
        PlayerPrefs.SetInt("AutoSave", 4);
    }

}
