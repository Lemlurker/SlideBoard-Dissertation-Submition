using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MagGun : MonoBehaviour
{
    public GameObject Target;
    public TriggerHand CarContact;
    public SlideboardLocomotion1 Player;
    public float CarSpeed;
    public Speed MeAvgSpeed;

    public GameObject Car1;
    
    public MoveOnPath Car1Move;
    public GameObject Car2;
    public MoveOnPath Car2Move;
    public GameObject Car3;
    public MoveOnPath Car3Move;
    public GameObject Car4;
    public MoveOnPath Car4Move;
    public bool hasCharge;
    public GameObject Me;
    public SlideboardLocomotion1 MeSpeed;
    public float MeSpeedSet;
 
    public Speed TargetSpeed;
    public float Distance;
    public float ClosingSpeed;
    public float ClosingSpeedMax;
    public float ClosingSpeedFalloff;
    public float ClosingSpeedFalloffRate;

    public float Charge;
    public float ChargeBurnRate;
    private float chargBurnRateOld;
    public bool IsPressed;
    public float ReleaseTime;
    public float ReleaseThreshold;
    public float ChargeGenRate;
    public float MaxCharge;

    public float distance;

    public GameObject ChargeText;
    private float ChargeZScale;

    public GameObject ChargeTextWarn;
    private float WarnZScale;
    public GameObject ChargeTextOut;
    private float OutZScale;
    public int TextOutput;
    public Material GlowyBits;
    public TextMesh Strength;
    private float ColourMultiplier;
    public float ColourMultiplierMax;
    public Light PointLight1;
    public Light pointlight2;
    public float ScaleDebug;
    private float FlashTimer;
    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(GripPressedL, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabGrip.AddOnStateUpListener(GripReleasedL, SteamVR_Input_Sources.LeftHand);
        ChargeZScale = ChargeText.transform.localScale.z;
        WarnZScale = ChargeTextWarn.transform.localScale.z;
        OutZScale = ChargeTextOut.transform.localScale.z;
        chargBurnRateOld = ChargeBurnRate;

    }
    private void GripPressedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        IsPressed = true;
    }

    private void GripReleasedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        IsPressed = false;
        MeSpeed.ForwardVelocity = (MeAvgSpeed.movingAverage - MeAvgSpeed.movingAverage / 10) * Time.fixedDeltaTime;
    }

    void Update()
    {
        if(Car1.activeInHierarchy == true)
        {
            Target = Car1;
            MeSpeedSet = Car1Move.Speed;
            CarSpeed = Car1Move.Speed;
        }
        if (Car2.activeInHierarchy == true)
        {
            Target = Car2;
            MeSpeedSet = Car2Move.Speed;
            CarSpeed = Car2Move.Speed;
        }
        if (Car3.activeInHierarchy == true)
        {
            MeSpeedSet = Car3Move.Speed;
            CarSpeed = Car3Move.Speed;
            Target = Car3;
        }
        if (Car4.activeInHierarchy == true)
        {
            MeSpeedSet = Car4Move.Speed;
            CarSpeed = Car4Move.Speed;
            Target = Car4;
        }

        if(Charge < 1 && hasCharge == true)
        {
            hasCharge = false;
            MeSpeed.ForwardVelocity = (MeAvgSpeed.movingAverage - MeAvgSpeed.movingAverage / 10) * Time.fixedDeltaTime;
        }
        if (Charge > 2) ;
        hasCharge = true;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsPressed == true && Charge > 0 )
        {
            ReleaseTime = 0;
            if(Player.Transition == true && ClosingSpeed > ClosingSpeedMax/10 && Player.halt == false)
            {
                ClosingSpeed = ClosingSpeed - (ClosingSpeedMax / 1000);
                Charge = Charge - (ChargeBurnRate/2 * Time.deltaTime);
            }
           

            if(Player.halt == true )
            {
                ChargeBurnRate = ChargeBurnRate / 10;
                

            }
            else ChargeBurnRate = chargBurnRateOld;

            if (Player.halt == true && ClosingSpeed < CarSpeed)
            {
                ChargeBurnRate = ChargeBurnRate / 2;
            }
            else ChargeBurnRate = chargBurnRateOld;

            if( ClosingSpeed > 0)
            {
                Me.transform.position = Vector3.MoveTowards(Me.transform.position, Target.transform.position, Time.fixedDeltaTime * (TargetSpeed.movingAverage + ClosingSpeed));

            }
            
            
                
            Charge = Charge - (ChargeBurnRate * Time.deltaTime);
                
            
            
        }

        if(IsPressed == false && Charge < MaxCharge)
        {
            ReleaseTime = ReleaseTime + Time.deltaTime;
            if(ReleaseTime > ReleaseThreshold)
            {
                Charge = Charge + ChargeGenRate * Time.deltaTime;
            }
        }

        if(CarContact.Triggered == true && IsPressed == true)
        {
            MeSpeed.ForwardVelocity = MeSpeedSet * Time.fixedDeltaTime;
        }
        

        distance = Vector3.Distance(Me.transform.position, Target.transform.position);

        Distance = distance;

        if ( distance < 1)
        {
            ClosingSpeed = 0;

        }

        if (distance > 1 && distance < ClosingSpeedFalloff)
        {
            ClosingSpeed = ClosingSpeedMax;
        }

        if(distance > ClosingSpeedFalloff )
        {
            ClosingSpeed = ClosingSpeedMax + (ClosingSpeedFalloffRate * (ClosingSpeedFalloff - distance));
        }

        if(ClosingSpeed < 0)
        {
            ClosingSpeed = 0;
        }

        TextOutput = Mathf.RoundToInt(Charge);

        //Strength.text = System.Convert.ToString((ClosingSpeed / ClosingSpeedMax) * 100);

        ChargeText.transform.localScale = new Vector3(ChargeText.transform.localScale.x, ChargeText.transform.localScale.y, ((ChargeZScale / MaxCharge) * Charge));
        ChargeTextWarn.transform.localScale = new Vector3(ChargeTextWarn.transform.localScale.x, ChargeTextWarn.transform.localScale.y, ((WarnZScale / MaxCharge) * Charge));
        
        //ScaleDebug =ChargeZScale / ((ChargeZScale / MaxCharge) * Charge);
        if (Charge > 25)
        {
            ChargeText.SetActive(true);
            ChargeTextWarn.SetActive(false);
            ChargeTextOut.SetActive(false);
        }
        if (Charge < 25 && Charge > 1)
        {
            ChargeText.SetActive(false);
            ChargeTextWarn.SetActive(true);
            ChargeTextOut.SetActive(false);
        }
        if (Charge < 1)
        {
            ChargeText.SetActive(false);
            ChargeTextWarn.SetActive(false);
            
            FlashTimer = FlashTimer + Time.deltaTime;
            if(FlashTimer < 0.25)
            {
                ChargeTextOut.SetActive(true);
            }
            if(FlashTimer > 0.25)
            {
                ChargeTextOut.SetActive(false);
            }
            if(FlashTimer > 0.5)
            {
                FlashTimer = 0;
            }
        }
        //if(ChargeTextOut.activeInHierarchy == true && Charge < 1 && FlashTimer > 0.5)
        //{
        //    ChargeTextOut.SetActive(false);
        //    FlashTimer = 0;
        //}
        //if(ChargeTextOut.activeInHierarchy == false && Charge < 1 && FlashTimer > 0.5)
        //{
        //    ChargeTextOut.SetActive(true);
        //    FlashTimer = 0;
        //}
        

        ColourMultiplier = ColourMultiplierMax * ((ClosingSpeed / ClosingSpeedMax) * 100);

        GlowyBits.SetColor("_EmissionColor", new Vector4(255, 165, 0, 0)* ColourMultiplier);

        PointLight1.intensity = ClosingSpeed / ClosingSpeedMax;
        pointlight2.intensity = ClosingSpeed / ClosingSpeedMax;
    }
}
