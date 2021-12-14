using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MirrorActive : MonoBehaviour
{
    public GameObject Mirror;
    public GameObject OtherMirror;
    // Start is called before the first frame update
    void Start()
    {
        Mirror.SetActive(false);
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressedL, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(TriggerChangedL, SteamVR_Input_Sources.LeftHand);
    }



    private void TriggerPressedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (Mirror.activeInHierarchy == false && OtherMirror.activeInHierarchy == false)
        {
            Mirror.SetActive(true);
        }
    }
    private void TriggerChangedL(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Mirror.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
