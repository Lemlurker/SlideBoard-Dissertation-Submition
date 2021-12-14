using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHand : MonoBehaviour
{
    public bool Triggered;
    public bool LostContact;
    public MagGun MagGun;

    private void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "GrabArea")
        {
            Triggered = true;
            Debug.Log("HandEntered");
        }
        else
        {
            Triggered = false;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        /*
        if (col.gameObject.tag == "GrabArea")
        {
            LostContact = true;
            MagGun.IsPressed = false;
            MagGun.Charge = 0;
        }
        */
       
    }

}
