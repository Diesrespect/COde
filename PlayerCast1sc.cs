using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast1sc : MonoBehaviour
{

    public static float DistanceFromTarget;
    public float ToTarget;
    public GameObject PickFakePistolTrigger;
    public GameObject LookAtMeTarget;
    public Camera cum;
    //public GameObject Door1;

    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(cum.transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            ToTarget = Hit.distance;
            DistanceFromTarget = ToTarget;
        }

        if (PickFakePistolTrigger.activeInHierarchy == true)
        {
            transform.LookAt(PickFakePistolTrigger.transform);
        }

        //else if (LookAtMeTarget.activeInHierarchy == true)
        //{
        //    transform.LookAt(LookAtMeTarget.transform);
        //}
    }
}
