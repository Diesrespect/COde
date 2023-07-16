using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarZomDeadScene02 : MonoBehaviour
{
    public int EnemyHealth = 45;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource zombScreaming;
    public AudioSource zombDead;

    public AudioSource zombieHurt;
    public AudioClip[] zombHurtArray;

    public GameObject hurtCross;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
        
        StartCoroutine(hurtCrossFlash());
        zombieHurt.PlayOneShot(RandomClip());

    }

    IEnumerator hurtCrossFlash()
    {
        hurtCross.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hurtCross.SetActive(false);
    }

    
    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<WarZombAI>().enabled = false;
            this.GetComponent<Scene02StalkerAI>().enabled = false;
            
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            zombScreaming.Stop();
            StatusCheck = 2;
           
            zombDead.Play();
            
            TheEnemy.GetComponent<Animator>().Play("death");
            
        }
    }

    AudioClip RandomClip()
    {
        return zombHurtArray[Random.Range(0, zombHurtArray.Length)];
    }
}
