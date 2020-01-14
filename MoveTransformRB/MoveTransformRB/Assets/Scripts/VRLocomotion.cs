using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRLocomotion : MonoBehaviour
{
    public float Sens = 0.1f;
    public float maxSpeed = 1.0f;
    //
    public SteamVR_Action_Boolean movePress = null;
    public SteamVR_Action_Vector2 moveValue = null;
    // Private 
    private float speed = 0.0f;
    private CharacterController charControl = null;
    private Transform cameraRig = null;
    private Transform head = null;

    private void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }


    private void Start()
    {
        cameraRig = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().head;
    }


    private void Update()
    {
        handleHead();
        calcMovement();
        handleHeight();
    }

    private void handleHead()
    {
        Vector3 oldPos = cameraRig.position;
        Quaternion oldRotation = cameraRig.rotation;

        transform.eulerAngles = new Vector3(0.0f, head.rotation.eulerAngles.y, 0.0f);

        cameraRig.position = oldPos;
        cameraRig.rotation = oldRotation;
    }

    private void calcMovement()
    {
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        if (movePress.GetStateUp(SteamVR_Input_Sources.Any))
            speed = 0;

        if (movePress.state)
        {
            speed += moveValue.axis.y * Sens;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

            movement += orientation * (speed * Vector3.forward) * Time.deltaTime;
            Debug.Log(movement);
            Debug.Log(speed);
        }
        charControl.Move(movement);
        
    }
    private void handleHeight()
    {
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        charControl.height = headHeight;

        Vector3 newCenter = Vector3.zero;
        newCenter.y = charControl.height / 2;
        newCenter.y += charControl.skinWidth;
        newCenter.x += head.localPosition.x;
        newCenter.z += head.localPosition.z;

        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        charControl.center = newCenter;
    }
}
