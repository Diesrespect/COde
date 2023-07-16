using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class BZJumpTrigger : MonoBehaviour
{
    [Header("Camera FOV Settings")]
    [SerializeField] private float changeFovTime = 0.4f;
    [SerializeField] private float lookTime = 0.5f;
    [SerializeField] private float endFov = 60f;
    [SerializeField] private AnimationCurve fovCurve;
    [Space]
    public AudioSource DoorBang;
    public AudioSource DoorJumpMusic;
    public AudioSource GamePlayMus;
    public AudioSource SurpriseReplics;
    public AudioSource DoorKick;
    public GameObject ThePlayer;
    public GameObject TheZombie;
    public GameObject Door;
    public GameObject LookAtMeTarget;
    private Camera _cam;


    private void Start()
    {
        _cam = Camera.main;
    }

    void OnTriggerEnter()
    { 
        StartCoroutine(FullAction());
    }

    IEnumerator FullAction()
    {
        GetComponent<BoxCollider>().enabled = false;
        GamePlayMus.Stop();
        //ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        //LookAtMeTarget.SetActive(true);
        //yield return new WaitForSeconds(0.3f);
        DoorKick.Play();
        //yield return StartCoroutine(ChangeFovCO());
        yield return new WaitForSeconds(2f);
        //LookAtMeTarget.SetActive(false);
        //ThePlayer.GetComponent<FirstPersonController>().enabled = true;
        DoorKick.Stop();
        
        //yield return new WaitForSeconds(0.2f);
        Door.GetComponent<Animation>().Play("JumpscareDoorAnim");
        DoorBang.Play();
        TheZombie.SetActive(true);
        StartCoroutine(PlayJumpMusic());
    }

    IEnumerator PlayJumpMusic()
    {
        yield return new WaitForSeconds(0.4f);
        DoorJumpMusic.Play();
    }

    private IEnumerator ChangeFovCO()
    {
        var startFov = _cam.fieldOfView;
        var time = 0f;
        

        while(time < changeFovTime)
        {
            var lerpValue = fovCurve.Evaluate(time / changeFovTime);
            var fov = Mathf.Lerp(startFov, endFov, lerpValue);
            _cam.fieldOfView = fov;
            time += Time.deltaTime;
            yield return null;
        }

        
        SurpriseReplics.Play();
        yield return new WaitForSeconds(lookTime);
        time = 0f;
        while (time < changeFovTime)
        {
            var lerpValue = fovCurve.Evaluate(time / changeFovTime);
            var fov = Mathf.Lerp(endFov, startFov, lerpValue);
            _cam.fieldOfView = fov;
            time += Time.deltaTime;
            yield return null;
        }
        _cam.fieldOfView = startFov;

        yield break;
    }

    
}
