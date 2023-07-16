using System.Collections;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.01f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    //public int Status;
    public AudioSource hurtSound1;
    public AudioSource hurtSound2;
    public AudioSource hurtSound3;
    public AudioSource hurtSound4;
    public AudioSource hurtSound5;
    public int hurtGen;
    public AnimationClip walkClip;
    public AnimationClip attackClip;
    public GameObject hurtFlash;


    void Update()
    {
        var targetPos = thePlayer.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        if (attackTrigger == false)
        {
            enemySpeed = 0.1f;
            theEnemy.GetComponent<Animation>().Play(walkClip.name);
            
            transform.position = Vector3.MoveTowards(transform.position, targetPos, enemySpeed);
        }

        if (attackTrigger == true && isAttacking == false)
        {
            enemySpeed = 0;
            theEnemy.GetComponent<Animation>().Play(attackClip.name);
            StartCoroutine(InflicktDamage());
        }

    }

    //void StatusChk()
    //{
    //    Status = StatusCheck;
    //}


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
        yield return new WaitForSeconds(1.0f);
        GlobalHealth.currentHealth -= 5;
        hurtGen = Random.Range(1, 4);
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
