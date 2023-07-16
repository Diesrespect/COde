using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource Line00;
    public AudioSource Line01;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        FadeScreenIn.SetActive(true);
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "Oh no, where the hell am I?";
        Line00.Play();
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        TextBox.GetComponent<Text>().text = "I need to get out of here";
        Line01.Play();
        yield return new WaitForSeconds(4);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;
    }
}
