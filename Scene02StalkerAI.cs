using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Scene02StalkerAI : MonoBehaviour
{
    public GameObject stalkerDest;
    NavMeshAgent stalkerAgent;
    public GameObject stalkerEnemy;
    public static bool isStalking;
    public GameObject zomb;
    

    public AudioSource zombScream;


    void Scream(bool canZombieScream)
    {
        if (canZombieScream == true && zombScream.isPlaying == false)
            zombScream.Play();
        else if (canZombieScream == false)
            zombScream.Stop();
    }


    void Start()
    {
        //Scream(false);
        stalkerAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if (isStalking == false)
        {
            //Scream(false);
            stalkerEnemy.GetComponent<Animator>().Play("BreathingIdle");
        }
        else
        {
            if (zomb.GetComponent<WarZombAI>().attackTrigger == true)
            {
                Scream(false);
                stalkerAgent.speed = 0;
                stalkerEnemy.GetComponent<Animator>().Play("attack");
            }
            else
            {
                Scream(true);
                if (zomb.name == "ZombieLying")
                {
                    stalkerAgent.speed = 2f;
                }
                else
                {
                    stalkerAgent.speed = 5f;
                }

                stalkerAgent.SetDestination(stalkerDest.transform.position);
                stalkerEnemy.GetComponent<Animator>().Play("walking");

            }

        }


    }
}
