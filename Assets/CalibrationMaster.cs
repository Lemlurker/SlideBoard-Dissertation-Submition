using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationMaster : MonoBehaviour
{
    public bool Calibrated;
    public GameObject CalibrationZone;
    public GameObject SlideZone;
    public PuckCalibration LeftFootPuck;
    public PuckCalibration RightFootPuck;
    public PuckCalibration BodyPuck;
    public SlideboardLocomotion1 Movement;
    public GameObject Trackers;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Calibrated == true)
        {
            CalibrationZone.SetActive(false);
            SlideZone.SetActive(true);
            Movement.enabled = true;
            Trackers.SetActive(true);

        }
        if(Calibrated == false)
        {
            CalibrationZone.SetActive(true);
            SlideZone.SetActive(false);
            Movement.enabled = false;
            Trackers.SetActive(false);
        }

        if(LeftFootPuck.Calibrate == true && RightFootPuck.Calibrate == true && BodyPuck.Calibrate == true)
        {
            Calibrated = true;
            LeftFootPuck.Calibrate = true;
            RightFootPuck.Calibrate = true;
            BodyPuck.Calibrate = true;
        }
    }
}
