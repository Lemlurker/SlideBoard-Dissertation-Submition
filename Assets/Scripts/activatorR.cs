using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatorR : MonoBehaviour
{
    public bool HasBeenTriggered;
    public int triggerFrameCount;
    public int TriggerCount;
    public int TriggerCountOld;

    // Start is called before the first frame update
    void Start()
    {
        HasBeenTriggered = false;
        TriggerCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerCount != TriggerCountOld)
        {
            TriggerCountOld = TriggerCount;
        }
        if (HasBeenTriggered == true)
        {
            triggerFrameCount = triggerFrameCount + 1;
            if (triggerFrameCount > 1)
            {
                TriggerCount = TriggerCount + 1;
                HasBeenTriggered = false;
                triggerFrameCount = 0;
            }

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.name == "FootR")
        {
            HasBeenTriggered = true;      

        }
    }
}
