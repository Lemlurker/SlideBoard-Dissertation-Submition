using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GripLock : MonoBehaviour
{
    public TriggerHand RightHand;
    public bool Lock;
    public bool WasLockState;
    public GameObject LockTarget1;
    public MoveOnPath LockTarget1Speed;
    public GameObject LockTarget2;
    public MoveOnPath LockTarget2Speed;
    public GameObject LockTarget3;
    public MoveOnPath LockTarget3Speed;
    public GameObject LockTarget4;
    public MoveOnPath LockTarget4Speed;
    public Quaternion LockTargetRotation;
    public Quaternion CurrentRotation;
    public SlideboardLocomotion1 PlayerSpeed;
    public float RotationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(GripPressedR, SteamVR_Input_Sources.RightHand);
        SteamVR_Actions.default_GrabGrip.AddOnStateUpListener(GripReleasedR, SteamVR_Input_Sources.RightHand);
    }

    

    private void GripPressedR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if( RightHand.Triggered == true)
        {
            Lock = true;
        }
        else
        {
            Lock = false;
        }

    }
    private void GripReleasedR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Lock = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(RightHand.Triggered == false)
        {
            Lock = false;
        }
        CurrentRotation = transform.localRotation;
        if (Lock == true)
        {
            


            if(LockTarget1.activeInHierarchy == true)
            {
                PlayerSpeed.ForwardVelocity = LockTarget1Speed.Speed * Time.fixedDeltaTime;
                LockTargetRotation = LockTarget1.transform.rotation;
            }
            if (LockTarget2.activeInHierarchy == true)
            {
                PlayerSpeed.ForwardVelocity = LockTarget2Speed.Speed * Time.fixedDeltaTime;
                LockTargetRotation = LockTarget2.transform.rotation;
            }
            if (LockTarget3.activeInHierarchy == true)
            {
                PlayerSpeed.ForwardVelocity = LockTarget3Speed.Speed * Time.fixedDeltaTime;
                LockTargetRotation = LockTarget3.transform.rotation;
            }
            if (LockTarget4.activeInHierarchy == true)
            {
                PlayerSpeed.ForwardVelocity = LockTarget4Speed.Speed * Time.fixedDeltaTime;
                LockTargetRotation = LockTarget4.transform.rotation;
            }
            

            transform.rotation = LockTargetRotation;

           
            
            







        }
    }
}
