using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalHealth : MonoBehaviour
{
    public static int currentHealth = 100;
    public int internalHealth;
    public GameObject HealthDisplay;

    void Update()
    {
        HealthDisplay.GetComponent<Text>().text = "" + internalHealth;
        internalHealth = currentHealth;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
