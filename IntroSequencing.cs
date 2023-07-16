using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSequencing : MonoBehaviour
{
    public GameObject textBox;
    public GameObject dateDisplay;
    public GameObject placeDisplay;
    public AudioSource line01;
    public AudioSource line02;
    public AudioSource line03;
    public AudioSource line04;
    public AudioSource line05;
    public AudioSource thudSound;
    public AudioSource fallingSound;
    public GameObject allBlack;
    public GameObject loadText;


    void Start()
    {
        StartCoroutine(SequenceBegin());
    }

    IEnumerator SequenceBegin()
    {
        yield return new WaitForSeconds(3);
        placeDisplay.SetActive(true);
        yield return new WaitForSeconds(1);
        dateDisplay.SetActive(true);
        yield return new WaitForSeconds(8);
        placeDisplay.SetActive(false);
        dateDisplay.SetActive(false);
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "The night of September 18, 2011 changed me forever";
        line01.Play();
        yield return new WaitForSeconds(5);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "I went to explore the insufferable sounds in the woods";
        line02.Play();
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(11);
        textBox.GetComponent<Text>().text = "I followed the sounds, and they got closer and scarier";
        line03.Play();
        yield return new WaitForSeconds(4.4f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(8);
        textBox.GetComponent<Text>().text = "I stumbled across a lawn with a shed in the distance";
        line04.Play();
        yield return new WaitForSeconds(4.1f);
        textBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(37);
        allBlack.SetActive(true);
        thudSound.Play();
        yield return new WaitForSeconds(0.2f);
        fallingSound.Play();
        yield return new WaitForSeconds(0.3f);
        loadText.SetActive(true);
        SceneManager.LoadScene(3);
    }

}
