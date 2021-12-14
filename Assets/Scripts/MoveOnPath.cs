using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{
    // Start is called before the first frame update
    public PathEditorVisualiser PathToFollow;
    //public CarSpawnee CarSpawner;
    public GameObject CarObj;
    public GameObject CarMesh;
    public int CurrentWayPointID;
    public CarSpawner LocationSpawner;
    public float Speed;
    private float speed;
    public float ReachDistance = 1.0f;
    public float rotationSpeed = 5.0f;
    public string pathName;
    public int StartPosition;
    public int StartPositionSet = 1842;

    Vector3 Last_position;
    Vector3 current_Position;

    void Start()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<PathEditorVisualiser>();
        Last_position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.path_objs[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if(distance <= ReachDistance)
        {
            CurrentWayPointID = CurrentWayPointID - 1;

        }
        if(CurrentWayPointID < 0) //= PathToFollow.path_objs.Count
        {
            CurrentWayPointID = StartPositionSet;
            CarObj.SetActive(false);
            
        }
        if(CurrentWayPointID == LocationSpawner.NextSpawnLocation)
        {
            speed = 10000;
            CarMesh.SetActive(false);
        }
        else
        {
            speed = Speed;
            CarMesh.SetActive(true);
        }
    }
}
