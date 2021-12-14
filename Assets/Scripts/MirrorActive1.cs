using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MirrorActive1 : MonoBehaviour
{
    public GameObject Mirror;
    public GameObject OtherMirror;
    // Start is called before the first frame update
    void Start()
    {
        Mirror.SetActive(false);
        SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(TriggerPressedR, SteamVR_Input_Sources.RightHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(TriggerChangedR, SteamVR_Input_Sources.RightHand);
    }

   

    private void TriggerPressedR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (Mirror.activeInHierarchy == false && OtherMirror.activeInHierarchy == false)
        {
            Mirror.SetActive(true);
        }
    }
    private void TriggerChangedR(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Mirror.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
