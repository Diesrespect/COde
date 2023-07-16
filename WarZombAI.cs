using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WarZombAI : MonoBehaviour
{
    public GameObject theEnemy;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public AudioSource hurtSound4;
    public AudioSource hurtSound5;
    public int hurtGen;
    public GameObject hurtFlash;

    //public AudioClip attackScream01;
    //public AudioClip attackScream02;
    //public AudioClip attackScream03;
    //public AudioClip attackScream04;
    //public AudioClip attackScream05;
    

    void Update()
    {
        

       
        if (attackTrigger == true && isAttacking == false)
        {
            StartCoroutine(InflicktDamage());
        }
       

    }

    void OnTriggerEnter()
    {
        
        attackTrigger = true;
    }

    void OnTriggerExit()
    {
        attackTrigger = false;
    }

    IEnumerator InflicktDamage()
    {
       
        isAttacking = true;
        if (hurtGen == 1)
        {
            hurtSound1.Play();
        }

        if (hurtGen == 2)
        {
            hurtSound2.Play();
        }

        if (hurtGen == 3)
        {
            hurtSound3.Play();
        }
        if (hurtGen == 4)
        {
            hurtSound4.Play();
        }
        if (hurtGen == 5)
        {
            hurtSound5.Play();
        }
        hurtFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hurtFlash.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GlobalHealth.currentHealth -= 5;
        hurtGen = Random.Range(1, 4);
        yield return new WaitForSeconds(0.15f);
        isAttacking = false;
    }
}
