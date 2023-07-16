using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseBrake : MonoBehaviour
{
    public GameObject fakeVase;
    public GameObject brokenVase;
    public GameObject sphereObject;
    public GameObject theKey;
    public GameObject keyTrigger;
    public AudioSource breakingSound;

    void DamageZombie(int DamageAmount)
    {
        StartCoroutine(BreakVase());

    }

    IEnumerator BreakVase()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        fakeVase.SetActive(false);
        brokenVase.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        breakingSound.Play();
        sphereObject.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        sphereObject.SetActive(false);
        theKey.SetActive(true);
        keyTrigger.SetActive(true);
    }
}
