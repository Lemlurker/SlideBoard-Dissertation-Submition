using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPositionClone : MonoBehaviour
{
    public GameObject Vehicle;
    public LocalVsWorld XPositionVector;
    public Vector3 LocalPosition;
    public Vector3 TargetPosition;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vehicle.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        LocalPosition = transform.localPosition;
        TargetPosition = new Vector3(XPositionVector.XDistance, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = TargetPosition;
    }
}
