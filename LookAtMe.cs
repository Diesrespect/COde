using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{

    //public static float DistanceFromTarget;
    //public float ToTarget;
    public GameObject PickFakePistolTrigger;
    public GameObject LookAtMeTarget;
    //public GameObject Door1;

    void Update()
    {
        /*RaycastHit Hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }*/

        if (PickFakePistolTrigger.activeInHierarchy == true)
        {
            transform.LookAt(PickFakePistolTrigger.transform);
        }

        if (LookAtMeTarget.activeInHierarchy == true)
        {
            transform.LookAt(LookAtMeTarget.transform);
        }
    }
}
