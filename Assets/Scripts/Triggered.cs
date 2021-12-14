using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggered : MonoBehaviour
{
    // Start is called before the first frame update
    public bool triggered;
    public string TriggererTag;


    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == TriggererTag)
        {
            triggered = true;
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == TriggererTag)
        {
            triggered = false;
        }
    }

}
