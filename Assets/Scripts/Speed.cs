using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speed; //this is an example for the value to be averaged
    public int MovingAverageLength = 10; //made public in case you want to change it in the Inspector, if not, could be declared Constant
    private Vector3 lastPosition;
    private int count;
    public float movingAverage;


    // Update is called once per frame
    void Update()
    {
        count++;

        //This will calculate the MovingAverage AFTER the very first value of the MovingAverage
        if (count > MovingAverageLength)
        {
            movingAverage = movingAverage + (speed - movingAverage) / (MovingAverageLength + 1);

            //Debug.Log("Moving Average: " + movingAverage); //for testing purposes

        }
        else
        {
            //NOTE: The MovingAverage will not have a value until at least "MovingAverageLength" values are known (10 values per your requirement)
            movingAverage += speed;

            //This will calculate ONLY the very first value of the MovingAverage,
            if (count == MovingAverageLength)
            {
                movingAverage = movingAverage / count;
                //Debug.Log("Moving Average: " + movingAverage); //for testing purposes
            }
        }



        Vector3 lastPosition = Vector3.zero;
    }
    void FixedUpdate()
    {
        speed = ((transform.position - lastPosition).magnitude)/Time.fixedDeltaTime;
        lastPosition = transform.position;
    }
}
    
