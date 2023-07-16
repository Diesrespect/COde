using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath : MonoBehaviour
{
    public int EnemyHealth = 25;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpscareMusic;
    public AudioSource GamePlayMus;
    public AnimationClip walkClip;
    public AnimationClip fallClip;
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
            this.GetComponent<ZombieAI>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            //SendMessage("StatusChk", StatusCheck, SendMessageOptions.DontRequireReceiver);
            TheEnemy.GetComponent<Animation>().Stop(walkClip.name);
            zombScreaming.Stop();
            zombDead.Play();
            //TheEnemy.GetComponent<Animation>().Stop("Attack");
            TheEnemy.GetComponent<Animation>().Play(fallClip.name);
            JumpscareMusic.Stop();
            GamePlayMus.Play();

        }
    }
}
