using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildRotator : MonoBehaviour
{
    public float StepAmmount;
    public Vector3 ObjectOrigin;
    public Vector3 ObjectOriginUp;
    public Vector3 ObjectOriginDwn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectOrigin = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        ObjectOriginUp = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + StepAmmount);
        ObjectOriginDwn = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - StepAmmount);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Road")
        {
            transform.position = ObjectOriginUp;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Road")
        {
            transform.position = ObjectOriginDwn;
        }
    }
}
