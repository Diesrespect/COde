using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookJumpTrigger : MonoBehaviour
{
    public GameObject bookObject;
    public GameObject sphereTrig;
    public AudioSource breakingGlass;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        sphereTrig.SetActive(true);
        StartCoroutine(DeactivateSphere());
        //bookObject.GetComponent<Animator>().Play("JumpingBook");
    }

    IEnumerator DeactivateSphere()
    {
        yield return new WaitForSeconds(0.5f);
        sphereTrig.SetActive(false);
        //yield return new WaitForSeconds(0.8f);
        //breakingGlass.Play();
    }
}
