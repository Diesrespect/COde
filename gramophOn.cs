using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gramophOn : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    
    public AudioSource music;
    public AudioClip[] musicArray;
    public AudioSource RadioTurn;
    public AudioSource RadioOff;

    public bool radioTurned;

    private void Start()
    {
        radioTurned = false;
    }

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            if (radioTurned == true)
            {
                ExtraCross.SetActive(true);
                ActionText.GetComponent<Text>().text = "turn off the gramophone";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);

            }
            else
            {
                ExtraCross.SetActive(true);
                ActionText.GetComponent<Text>().text = "turn on the gramophone";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);

            }

        }

        if (Input.GetButtonDown("Action"))
        {
            

            if (TheDistance <= 5)
            {
                if (radioTurned == true)
                {
                    RadioOff.Play();
                    music.Stop();
                    radioTurned = false;
                    
                }
                else if(radioTurned == false)
                {
                    music.PlayOneShot(RandomClip());
                    RadioTurn.Play();
                    
                    
                    radioTurned = true;
                }

            }
        }
    }

    private void OnMouseExit()
    {
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
        ExtraCross.SetActive(false);
    }

    AudioClip RandomClip()
    {
        return musicArray[Random.Range(0, musicArray.Length)];
    }

}

