using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWaveTrigger : MonoBehaviour
{
    public GameObject zombieSpawner;
    public GameObject Door;
    public AudioSource DoorOpen;
    public GameObject RedLight;
  

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaveBegins());

        
    }

    IEnumerator WaveBegins()
    {
        RedLight.SetActive(true);
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        DoorOpen.Play();
        yield return new WaitForSeconds(0.5f);
        zombieSpawner.SetActive(true);
        
        Door.GetComponentInChildren<Animator>().Play("Open");
    }
}
