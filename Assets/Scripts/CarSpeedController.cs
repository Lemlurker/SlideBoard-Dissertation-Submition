using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpeedController : MonoBehaviour
{
    public MoveOnPath CarControl;
    public Speed PlayerSpeed;
    
    public Triggered ForwardTrigger;
    public Triggered BackTrigger;
    public Triggered MissedTrigger;
    public float Accelleration;
    public float PlayerSpeedVal;
    public float speedSetPoint;
    public bool Forward;
    public bool Middle;
    public bool Rear;
    public float Speed = 25;

    public bool WithinReach;
    public bool HasBeenClose;

    public float CatchupSupSpeed;
    public float CreapSupSpeed;
    public float MissedSloSpeed;

    void Update()
    {
        
        PlayerSpeedVal = PlayerSpeed.movingAverage;

        if(ForwardTrigger.triggered == true)
        {
            speedSetPoint = PlayerSpeedVal + (CatchupSupSpeed * PlayerSpeedVal);
            Forward = true;
            WithinReach = true;
            HasBeenClose = true;
        }
        if (ForwardTrigger.triggered == false)
        {
           
            Forward = false;
        }


        if (BackTrigger.triggered == true)
        {
            speedSetPoint = PlayerSpeedVal + (CreapSupSpeed * PlayerSpeedVal);
            Middle = true;
            WithinReach = true;
            HasBeenClose = true;
        }
        if (BackTrigger.triggered == false)
        {
            
            Middle = false;
        }


        if (MissedTrigger.triggered == true)
        {
            speedSetPoint = PlayerSpeedVal - (MissedSloSpeed * PlayerSpeedVal);
            Rear = true;
            WithinReach = true;
            HasBeenClose = true;
        }
        if (MissedTrigger.triggered == false)
        {
            
            Rear = false;
        }

        if(speedSetPoint > 35)
        {
            speedSetPoint = 35;
        }

        if (ForwardTrigger.triggered == false )
        {
            if(BackTrigger.triggered == false)
            {
                if(MissedTrigger.triggered == false)
                {
                    speedSetPoint = Speed;
                    if(HasBeenClose == true)
                    {
                        WithinReach = false;
                        
                    }
                    
                }
            }
        }

        //speed average

        if(speedSetPoint > CarControl.Speed)
        {
            CarControl.Speed = CarControl.Speed + (Accelleration * Time.deltaTime);
        }

        if(speedSetPoint < CarControl.Speed)
        {
            CarControl.Speed = CarControl.Speed - (Accelleration * Time.deltaTime);
        }
    }
}
