using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInvertory : MonoBehaviour
{
    public static bool firstDoorKey = false;
    public static bool rightEye = false;
    public static bool leftEye = false;
    public bool internalDoorKey;
    public bool internalLeftEye;
    public bool internalRightEye;
   

    void Update()
    {
        internalDoorKey = firstDoorKey;
        internalLeftEye = leftEye;
        internalRightEye = rightEye;
    }
}
