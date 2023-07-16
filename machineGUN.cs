using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineGUN : MonoBehaviour
{

    [SerializeField] private Transform yRotationTarget;
    [SerializeField] private Transform xRotationTarget;
    [Space]
    [SerializeField] private float yRotationConstraint = 45f;
   // [SerializeField] private float xRotationMin = -15f;
   // [SerializeField] private float xRotationMax = 25f;
    [SerializeField] private float rotationSpeed = 3f;
    public bool _isEnable = false;
    private Vector3 _yTargetStartForward;
    private Vector3 _xTargetStartForward;


    // Start is called before the first frame update
    void Start()
    {
        _yTargetStartForward = yRotationTarget.forward;
        _xTargetStartForward = xRotationTarget.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isEnable) return;

       
        var inputX = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
        xRotationTarget.Rotate(new Vector3(inputX, 0, 0), Space.Self);

        InputY();

       
    }

    private void InputY()
    {
        var inputY = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;

        yRotationTarget.Rotate(new Vector3(0, inputY, 0), Space.Self);

        var angle = Vector3.SignedAngle(_yTargetStartForward, yRotationTarget.forward, yRotationTarget.up);

        //Debug.Log($"input Y: {inputY}, local rotationb Y: {yRotationTarget.localRotation.eulerAngles.y}");

        if (angle > yRotationConstraint)
        {
            var rotation = yRotationTarget.localRotation.eulerAngles;
            yRotationTarget.localRotation = Quaternion.Euler(rotation.x, yRotationConstraint, rotation.z);
        }
        else if (angle < -yRotationConstraint)
        {
            var rotation = yRotationTarget.localRotation.eulerAngles;
            yRotationTarget.localRotation = Quaternion.Euler(rotation.x, -yRotationConstraint, rotation.z);
        }
    }
}
