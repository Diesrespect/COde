using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RadioTurnOn : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    //public GameObject Radio;
    public AudioSource RadioTurn;
    public AudioSource RadioOff;
    public AudioSource RadioSpeech01;
    //public AudioSource RadioSpeech02;
    //public AudioSource RadioSpeech03;
    public bool radioTurned = true;
    public GameObject radDisplay;

    public int toPlay;
    public int whatIsPlaying;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            if(radioTurned == true)
            {
                ExtraCross.SetActive(true);
                ActionText.GetComponent<Text>().text = "turn off the radio";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                
            }
            else
            {
                ExtraCross.SetActive(true);
                ActionText.GetComponent<Text>().text = "turn on the radio";
                ActionDisplay.SetActive(true);
                ActionText.SetActive(true);
                
            }
  
        }

        if (Input.GetButtonDown("Action"))
        {
            //toPlay = Random.Range(0, 3);
            //whatIsPlaying = toPlay;

            if (TheDistance <= 5)
            {
                if(radioTurned == true)
                {
                    RadioOff.Play();
                    RadioSpeech01.Pause();
                    radioTurned = false;
                    radDisplay.SetActive(false);
                }
                else
                {
                    RadioSpeech01.Play();
                    RadioTurn.Play();
                    //whatToPlay(toPlay);
                    radDisplay.SetActive(true);
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

    

}

