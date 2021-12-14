using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnee : MonoBehaviour
{
    public GameObject CarObject;
    public MoveOnPath CarController;
    public int SpawnLocation;
    public float CatchupSpeed;


   // private void OnTriggerEnter(Collision collision)
  //  {
     //   if(collision.gameObject.tag == "player")
     //   {
     //       CarObject.SetActive(true);
      //      CarController.Speed = CatchupSpeed;
         //   CarController.CurrentWayPointID = SpawnLocation;
       // }
   // }
}
