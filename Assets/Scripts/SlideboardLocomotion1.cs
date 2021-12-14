using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SlideboardLocomotion1 : MonoBehaviour
{   
    public activatorL LeftActivator;
    public GameObject LeftActivatorObj;
    public activatorR RightActivator;
    public GameObject RightActivatorObj;
    public bool Triggered;
    private bool TriggerLeft;
    private bool TriggerRight;
    private int frameCountL;
    private int frameCountR;
    public Rigidbody SlideboardRB;
    public GameObject Slidezone;
    public GameObject Head;
    public GameObject Body;
    private float HeadXPos;
    private float BodyXPos;
    private float BodyYPos;
    private float BodyYPosStart;
    private float BodyHightDifference;
    [Range(0.0f, 5f)]
    public float CrouchLimit;
    public bool Crouched;
    private float Difference;
    private float DifferenceScaled;
    [Range(0.0f, 0.5f)]
    public float Deadzone;
    [Range(0.0f, 1.0f)]
    public float Endzone;
    [Range(0.0f, 100.0f)]
    public float MaxTurnRate;
    public float RotationAmount;
    Vector3 AngularVelocity;
    public int RotationDirection;
    [Range(0.0f, 0.5f)]
    public float BaseVelocity;
    [Range(0.0f, 0.05f)]
    public float BaseDrag;
    [Range(10f, 200f)]
    public float LowVelocityDragMulti;
    public float CurrentDrag;
    public float ForwardVelocity;
    public bool TutorialTrigger;
    public bool InTutorial;

    private Vector3 LastLocation;
    private Vector3 CachedLocation;
    private int LoopChecker;
    
    [Range(1.0f, 500f)]
    public float UpHillSpeedMulti;
    [Range(1.0f, 500f)]
    public float DownHillSpeedMulti;
    [Range(-1.0f, 1.0f)]
    public float CrouchHillDragMuti;
    [Range(0.0f, 0.01f)]
    public float DragReductionBleedOff;

    public Speed PlayerSpeed;
    public float PlayerVelocitySet;
    //spawners
    public float CatchupSpeed;
    public GameObject Car1;
    public MoveOnPath Car1Cont;
    public int SpawnLocation1;
    public bool Transition;
    public bool halt;
   

    // Start is called before the first frame update
    void Start()
    {
        CachedLocation = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        ForwardVelocity = 0;
        BodyYPosStart = BodyYPos;
        SteamVR_Actions.default_GrabGrip.AddOnStateUpListener(GripReleasedL, SteamVR_Input_Sources.LeftHand);

    }

    private void GripReleasedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if(PlayerSpeed.movingAverage + 1 > PlayerVelocitySet)
        {
            ForwardVelocity = ((PlayerSpeed.movingAverage * Time.fixedDeltaTime) - (PlayerSpeed.movingAverage * Time.fixedDeltaTime / 10));
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDrag = BaseDrag;
        

        HeadXPos = Head.transform.localPosition.x;
        BodyXPos = Body.transform.localPosition.x;
        BodyYPos = Body.transform.localPosition.y;
        BodyHightDifference = BodyYPosStart - BodyYPos;

        if(BodyYPosStart < BodyYPos)
        {
            BodyYPosStart = BodyYPos; // sets the maximum height the body tracker can be below which the crouched state occues, needs remeding to prevent jumpign breaking it.
        }

        Difference = HeadXPos - BodyXPos; // calculates the diff between head and body lateral pos, needs fixing to be reletive to head axis
        if(DifferenceScaled < Deadzone)
        {
            RotationAmount = 0; // kills rotation below deadzone
            RotationDirection = 0;
        }
        if(DifferenceScaled > Deadzone && DifferenceScaled < Endzone)
        {
            RotationAmount = (DifferenceScaled - Deadzone) * MaxTurnRate * RotationDirection * (1/Endzone); //rotates if x difference > than deadzone but less than end
        }
        if(DifferenceScaled > Endzone)
        {
            RotationAmount = MaxTurnRate * RotationDirection; //if differnece is beyond the endzone then set to maximum turn rate
        }
        if(Difference < 0)
        {
            DifferenceScaled = Difference - (2 * Difference);//set rotationn direction
            RotationDirection = -1;
        }
        else
        {
            DifferenceScaled = Difference; //sets rotation direction inverted
            RotationDirection = 1;
        }
        AngularVelocity = new Vector3(0, RotationAmount, 0); //sets Angular velocity

        if(LeftActivator.HasBeenTriggered == true) // when the trigger on the left is triggered set the triggered bool to true
        {
            Triggered = true;
            TriggerLeft = true;
            
        }
        if(TriggerLeft == true)
        {
            frameCountL = frameCountL + 1;
            if(frameCountL > 2)
            {
                TriggerLeft = false;
                frameCountL = 0;
                RightActivatorObj.SetActive(true);
                LeftActivatorObj.SetActive(false);
            }
        }
        if (RightActivator.HasBeenTriggered == true)
        {
            Triggered = true;
            TriggerRight = true;// when the trigger on the right is triggered set the triggered bool to true
            


        }
        if (TriggerRight == true)
        {
            frameCountR = frameCountR + 1;
            if (frameCountR > 2)
            {
                TriggerRight = false;
                frameCountR = 0;
                RightActivatorObj.SetActive(false);
                LeftActivatorObj.SetActive(true);
            }
        }

        if ( Triggered == true) // when the ends have been triggered:
        {
            ForwardVelocity = ForwardVelocity + BaseVelocity; // set velocity
            Triggered = false; //reset trigger
            //Debug.Log("Triggered"); //debug : REMOVE
            LastLocation = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
            
            LoopChecker = 0;
        }
        /*if(BodyHightDifference > CrouchLimit) //detect if player is crouched
        {
            CurrentDrag = BaseDrag * CrouchHillDragMuti; //modify drag, can make negative to accellerate, will probably add bleed to reduce effectiveness
            Crouched = true; //modify bool for debug
            

        }
        else
        {
            CurrentDrag = BaseDrag; // reset drag
            Crouched = false; //reset debug bool
        }*/
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            transform.position = LastLocation;
            ForwardVelocity = 0;
            LoopChecker = LoopChecker + 1;
            LeftActivatorObj.SetActive(true);
            RightActivatorObj.SetActive(true);
            if(LoopChecker > 2)
            {
                transform.position = CachedLocation;
            }
        }
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Checkpoint")
        {
            CachedLocation = LastLocation;
        }
        
        

    }
    private void OnTriggerStay(Collider Col)
    {
        /*
        if(Col.gameObject.tag == "Downhill")
        {
            ForwardVelocity = ForwardVelocity + BaseVelocity / DownHillSpeedMulti;
        }
        if(Col.gameObject.tag == "Uphill")
        {
            if (Col.gameObject.tag == "Downhill")
            {if(ForwardVelocity < -0.01)
                {
                    ForwardVelocity = ForwardVelocity - BaseVelocity / UpHillSpeedMulti;
                }
                
            }
        }*/
        if (Col.gameObject.tag == "TutorialZoneProgress")
        {
            TutorialTrigger = true;
        }
        
        if(Col.gameObject.tag == "InTutorial")
        {
            InTutorial = true;
        }
        if(Col.gameObject.tag == "TransitionZone")
        {
            Transition = true;
        }
        if(Col.gameObject.tag == "HaltZone")
        {
            halt = true;
        }
        
    }
    private void OnTriggerExit(Collider Col)
    {
        if (Col.gameObject.tag == "TutorialZoneProgress")
        {
            TutorialTrigger = false;
        }

        if (Col.gameObject.tag == "InTutorial")
        {
            InTutorial = false;
        }
        if (Col.gameObject.tag == "TransitionZone")
        {
            Transition = false;
        }
        if (Col.gameObject.tag == "HaltZone")
        {
            halt = false;
        }
    }



    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(AngularVelocity * Time.fixedDeltaTime); //constant update velocity
        SlideboardRB.MoveRotation(SlideboardRB.rotation * deltaRotation);
        Slidezone.transform.position += ForwardVelocity * Slidezone.transform.forward;

        PlayerVelocitySet = ForwardVelocity / Time.fixedDeltaTime;

        if (ForwardVelocity < 0.1 && ForwardVelocity > 0) // velociuty bleed under 0.1 velocity
        {
            ForwardVelocity = ForwardVelocity - (CurrentDrag/LowVelocityDragMulti);
        }
        if (ForwardVelocity > 0.1) // velocity bleed uover 0.1 velocity
        {
            ForwardVelocity = ForwardVelocity - (CurrentDrag * ForwardVelocity);
        }
        //if(CurrentDrag > BaseDrag)
        //{
        //    CurrentDrag = CurrentDrag + DragReductionBleedOff;
        //}
    }
}
