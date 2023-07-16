using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;
    public GameObject FirstTrigger;
    public AudioSource Line02;
    

    private void OnTriggerEnter(Collider other)
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "I think there’s a gun on the table";
        Line02.Play();
        TheMarker.SetActive(true);
        yield return new WaitForSeconds(3f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        FirstTrigger.GetComponent<BoxCollider>().enabled = false;
    }
}
