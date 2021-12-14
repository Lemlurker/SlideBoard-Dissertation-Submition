using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalVsWorld : MonoBehaviour
{
    public GameObject Vehicle;
    public Vector3 LocalPosition;
    public Vector3 RootPosition;
    public float XDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LocalPosition = transform.localPosition;
        RootPosition = Vehicle.transform.position;
        XDistance = transform.localPosition.x;

    }
}
