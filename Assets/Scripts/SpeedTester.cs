using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTester : MonoBehaviour
{
    public float SetSpeed;
    public float CalculatedSpeed;
    public float ActualSpeed;
    public Speed SpeedRecorder;
    // Start is called before the first frame update
    void Update()
    {
        CalculatedSpeed = SetSpeed / Time.fixedDeltaTime;
        ActualSpeed = SpeedRecorder.movingAverage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += SetSpeed * transform.forward;
    }
}
