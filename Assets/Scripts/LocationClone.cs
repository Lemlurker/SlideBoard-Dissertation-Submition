using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationClone : MonoBehaviour
{
    public GameObject ClonedObject0;
    public GameObject ClonedObject1;
    public GameObject ClonedObject2;
    public GameObject ClonedObject3;
    public Vector3 WorldPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        WorldPosition = transform.position;
        ClonedObject0.transform.position = WorldPosition;
        ClonedObject1.transform.position = WorldPosition;
        ClonedObject2.transform.position = WorldPosition;
        ClonedObject3.transform.position = WorldPosition;
    }
}
