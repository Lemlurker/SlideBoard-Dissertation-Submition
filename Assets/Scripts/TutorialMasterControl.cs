using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TutorialMasterControl : MonoBehaviour
{
    public GameObject Welcome, Movement, Movement2, Movement3, Movement4, Movement4Trigger, GunTutorial, PullTest, FreeRoam, ControlTipsObj, ControlTriggerTip, ControlGripTip, Battery1, Battery2,  Car, Car2;
    public MagGun MagGun;
    public MoveOnPath CarSpeed;
    public bool Cont;
    public bool Back;
    public int StepCount;
    public int PushCount;
    public Speed PlayerSpeed;
    public SlideboardLocomotion1 Player;

    private bool rotateDir1;
    private bool rotateDir2;
    void Start()
    {
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(GripPressedR, SteamVR_Input_Sources.RightHand);
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(GripPressedL, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressedL, SteamVR_Input_Sources.LeftHand);
        StepCount = 1;
    }

    private void TriggerPressedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if(GunTutorial.activeInHierarchy == true)
        {
            ControlTriggerTip.SetActive(false);
        }
    }

    private void GripPressedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
       if(GunTutorial.activeInHierarchy == false && Player.InTutorial == true)
        {
            Back = true;
        }
       if(GunTutorial.activeInHierarchy == true && Player.InTutorial == true)
        {
            ControlGripTip.SetActive(false);
        }
          
    }

    private void GripPressedR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Cont = true;
    }

    // Update is called once per frame
    void Update()
    {

        if(Cont == true)
        {
            StepCount++;
            Cont = false;
        }
        if(Back == true)
        {
            StepCount = StepCount - 1;
            Back = false;
        }

        if (StepCount == 1 && Player.InTutorial == true)
        {
            Welcome.SetActive(true);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            Car2.SetActive(false);
        }
        if (StepCount == 2 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(true);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            Car2.SetActive(false);



        }
        if (StepCount == 3 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(true);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            Car2.SetActive(false);

        }
        if (StepCount == 4 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(true);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            Car2.SetActive(false);

        }
        if (StepCount == 5 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(true);
            Movement4Trigger.SetActive(true);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            Car2.SetActive(false);

        }
        if (StepCount == 6 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(true);
            PullTest.SetActive(false);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(true);
            Car.SetActive(true);
            CarSpeed.Speed = 0;
            Car2.SetActive(false);

        }
        if (StepCount == 7 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(true);
            FreeRoam.SetActive(false);
            ControlTipsObj.SetActive(false);
            Car.SetActive(true);
            CarSpeed.Speed = 0;
            Car2.SetActive(false);



        }
        if (StepCount == 8 && Player.InTutorial == true)
        {
            Welcome.SetActive(false);
            Movement.SetActive(false);
            Movement2.SetActive(false);
            Movement3.SetActive(false);
            Movement4.SetActive(false);
            Movement4Trigger.SetActive(false);
            GunTutorial.SetActive(false);
            PullTest.SetActive(false);
            FreeRoam.SetActive(true);
            ControlTipsObj.SetActive(false);
            Car.SetActive(false);
            CarSpeed.Speed = 0;
            Car2.SetActive(true);

        }
        if (StepCount > 8 && Player.InTutorial == true)
        {
            StepCount = 1;
        }
        if (StepCount < 0 && Player.InTutorial == true)
        {
            StepCount = 1;
        }


        if(PlayerSpeed.movingAverage > 4  && StepCount == 4 && Player.InTutorial == true)
        {
            PushCount++;
        }

        if(PushCount == 4 && Movement3.activeInHierarchy == true && Player.InTutorial == true)
        {
            StepCount++;
        }

        if(Player.RotationAmount > 25 && Player.RotationDirection == 1 && Movement2.activeInHierarchy == true && Player.InTutorial == true)
        {
            rotateDir1 = true;
        }

        if (Player.RotationAmount < -25 && Player.RotationDirection == -1 && Movement2.activeInHierarchy == true && Player.InTutorial == true)
        {
            rotateDir2 = true;
        }
        if(rotateDir1 == true && rotateDir2 == true && Player.InTutorial == true)
        {
            rotateDir1 = false;
            rotateDir2 = false;
            StepCount++;
        }
        if(Player.TutorialTrigger == true && Movement4.activeInHierarchy == true && Player.InTutorial == true)
        {
            StepCount++;
        }

        if(MagGun.Charge < MagGun.MaxCharge/2 && GunTutorial.activeInHierarchy == true && Player.InTutorial == true)
        {
            Battery1.SetActive(false);
            Battery2.SetActive(false);
        }
        if(Battery1.activeInHierarchy == false && Battery2.activeInHierarchy == false && ControlGripTip.activeInHierarchy == false && ControlTriggerTip.activeInHierarchy == false && GunTutorial.activeInHierarchy == true && Player.InTutorial == true)
        {
            StepCount++;
        }


    }
}
