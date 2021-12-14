using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PuckCalibration : MonoBehaviour
{
    public SteamVR_TrackedObject Tracker;
    public int TrackerID;
    public bool Calibrate;

    
    public enum EIndex
    {
        None = -1,
        Hmd = (int)OpenVR.k_unTrackedDeviceIndex_Hmd,
        Device1,
        Device2,
        Device3,
        Device4,
        Device5,
        Device6,
        Device7,
        Device8,
        Device9,
        Device10,
        Device11,
        Device12,
        Device13,
        Device14,
        Device15,
        Device16
    }
    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Actions.default_GrabGrip.AddOnStateDownListener(GripSqueezedL, SteamVR_Input_Sources.LeftHand);  
        //Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device1;
    }

    private void GripSqueezedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Calibrate = true;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Device1")
        {
            TrackerID = 1;
        }
        if (col.gameObject.tag == "Device2")
        {
            TrackerID = 2;
        }
        if (col.gameObject.tag == "Device3")
        {
            TrackerID = 3;
        }
        if (col.gameObject.tag == "Device4")
        {
            TrackerID = 4;
        }
        if (col.gameObject.tag == "Device5")
        {
            TrackerID = 5;
        }
        if (col.gameObject.tag == "Device6")
        {
            TrackerID = 6;
        }
        if (col.gameObject.tag == "Device7")
        {
            TrackerID = 7;
        }
        if (col.gameObject.tag == "Device8")
        {
            TrackerID = 8;
        }
        if (col.gameObject.tag == "Device9")
        {
            TrackerID = 9;
        }
        if (col.gameObject.tag == "Device10")
        {
            TrackerID = 10;
        }
        if (col.gameObject.tag == "Device11")
        {
            TrackerID = 11;
        }
        if (col.gameObject.tag == "Device12")
        {
            TrackerID = 12;

        }
        if (col.gameObject.tag == "Device13")
        {
            TrackerID = 13;
        }
        if (col.gameObject.tag == "Device14")
        {
            TrackerID = 14;
        }
        if (col.gameObject.tag == "Device15")
        {
            TrackerID = 15;
        }
        if (col.gameObject.tag == "Device16")
        {
            TrackerID = 16;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Calibrate == true)
        {
            if (TrackerID == 1)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device1;
            }
            if (TrackerID == 2)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device2;
            }
            if (TrackerID == 3)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device3;
            }
            if (TrackerID == 4)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device4;
            }
            if (TrackerID == 5)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device5;
            }
            if (TrackerID == 6)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device6;
            }
            if (TrackerID == 7)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device7;
            }
            if (TrackerID == 8)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device8;
            }
            if (TrackerID == 9)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device9;
            }
            if (TrackerID == 10)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device10;
            }
            if (TrackerID == 11)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device11;
            }
            if (TrackerID == 12)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device12;
            }
            if (TrackerID == 13)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device13;
            }
            if (TrackerID == 14)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device14;
            }
            if (TrackerID == 15)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device15;
            }
            if (TrackerID == 16)
            {
                Tracker.index = (SteamVR_TrackedObject.EIndex)EIndex.Device16;
            }

        }
    }
}
