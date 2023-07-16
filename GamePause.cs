using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Timeline;

public class GamePause : MonoBehaviour
{
    public bool paused = false;
    public GameObject pauseScreen;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if(paused == false)
            {
                Time.timeScale = 0f;
                paused = true;
                pauseScreen.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                paused = false;
                pauseScreen.SetActive(false);
            }
        }
        
    }
}
