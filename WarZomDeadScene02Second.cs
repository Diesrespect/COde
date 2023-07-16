using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WarZomDeadScene02Second : MonoBehaviour
{
    public int EnemyHealth = 1000;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource zombScreaming;
    public AudioSource zombDead;

    public GameObject hurtCross;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;

        StartCoroutine(hurtCrossFlash());
        

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
            this.GetComponent<Scene02SecondStalkerAI>().enabled = false;
            
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            zombScreaming.Stop();
            StatusCheck = 2;
           
            zombDead.Play();
            
            TheEnemy.GetComponent<Animator>().Play("death");
            
        }
    }
}
