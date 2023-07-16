using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideBottle : MonoBehaviour
{
    public AudioSource breakingGlass;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 1)
        {
            breakingGlass.Play();
        }
    }
}
