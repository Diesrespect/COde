using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateStalkerScene02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Scene02StalkerAI.isStalking = true;
        
    }
}
