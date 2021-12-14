using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public int NextSpawnLocation;
    public bool OneIsSpawned;
    public bool OneIsExpired;
    public GameObject Car1;
    public MoveOnPath Car1Control;
    public CarSpeedController Car1Speed;
    public float Car1DespawnTimer;

    public bool TwoIsSpawned;
    public bool TwoIsExpired;
    public GameObject Car2;
    public MoveOnPath Car2Control;
    public CarSpeedController Car2Speed;
    public float Car2DespawnTimer;

    public bool ThreeIsSpawned;
    public bool ThreeIsExpired;
    public GameObject Car3;
    public MoveOnPath Car3Control;
    public CarSpeedController Car3Speed;
    public float Car3DespawnTimer;

    public bool FourIsSpawned;
    public bool FourIsExpired;
    public GameObject Car4;
    public MoveOnPath Car4Control;
    public CarSpeedController Car4Speed;
    public float Car4DespawnTimer;

    public bool SpawnNext;
    public bool Spawned;
    public int LaneNumber;

    public float Timer;
    public float RandomTimerLimit;
    public float SpawnTimeMinimum;
    public float SpawnTimeMaximum;
    
    // Start is called before the first frame update
    void Start()
    {
        RandomTimerLimit = Random.Range(SpawnTimeMinimum, SpawnTimeMaximum);
    }

    // Update is called once per frame
    void Update()
    {

        if(SpawnNext == true)
        {
            Timer = 0;
            SpawnNext = false;
            Spawned = true;
            LaneNumber = Random.Range(1, 5);
            //random lane spawner
            if(LaneNumber == 1)
            {
                Car1Control.CurrentWayPointID = NextSpawnLocation;
                Car1.SetActive(true);
            }
            if (LaneNumber == 2)
            {
                Car2Control.CurrentWayPointID = NextSpawnLocation;
                Car2.SetActive(true);
            }
            if (LaneNumber == 3)
            {
                Car3Control.CurrentWayPointID = NextSpawnLocation;
                Car3.SetActive(true);
            }   
            if (LaneNumber == 4)
            {
                Car4Control.CurrentWayPointID = NextSpawnLocation;
                Car4.SetActive(true);
            }

        }
        //active cars
        if(Car1.activeInHierarchy == true)
        {
            OneIsSpawned = true;
        }
        else
        {
            OneIsSpawned= false;
        }
        if (Car2.activeInHierarchy == true)
        {
            TwoIsSpawned = true;
        }
        else
        {
            TwoIsSpawned = false;
        }
        if (Car3.activeInHierarchy == true)
        {
            ThreeIsSpawned = true;
        }
        else
        {
            ThreeIsSpawned = false;
            
        }
        if (Car4.activeInHierarchy == true)
        {
            FourIsSpawned = true;
        }
        else
        {
            FourIsSpawned = false;
        }

        if(Car1Speed.WithinReach == false && Car1.activeInHierarchy == true && Car1Speed.HasBeenClose == true)
        {
            Car1DespawnTimer = Car1DespawnTimer + Time.deltaTime;
            if(Car1DespawnTimer > 15)
            {
                Car1.SetActive(false);
                Car1Speed.HasBeenClose = false;
                RandomTimerLimit = Random.Range(SpawnTimeMinimum, SpawnTimeMaximum);
                Car1DespawnTimer = 0;
            }
        }
        if (Car2Speed.WithinReach == false && Car2.activeInHierarchy == true && Car2Speed.HasBeenClose == true)
        {
            Car2DespawnTimer = Car2DespawnTimer + Time.deltaTime;
            if (Car2DespawnTimer > 15)
            {
                Car2.SetActive(false);
                Car2Speed.HasBeenClose = false;
                RandomTimerLimit = Random.Range(SpawnTimeMinimum, SpawnTimeMaximum);
                Car2DespawnTimer = 0;
            }
        }
        if (Car3Speed.WithinReach == false && Car3.activeInHierarchy == true && Car3Speed.HasBeenClose == true)
        {
            Car3DespawnTimer = Car3DespawnTimer + Time.deltaTime;
            if (Car3DespawnTimer > 15)
            {
                Car3.SetActive(false);
                Car3Speed.HasBeenClose = false;
                RandomTimerLimit = Random.Range(SpawnTimeMinimum, SpawnTimeMaximum);
                Car3DespawnTimer = 0;
            }
        }
        if (Car4Speed.WithinReach == false && Car4.activeInHierarchy == true && Car4Speed.HasBeenClose == true)
        {
            Car4DespawnTimer = Car4DespawnTimer + Time.deltaTime;
            if (Car4DespawnTimer > 15)
            {
                Car4.SetActive(false);
                Car4Speed.HasBeenClose = false;
                RandomTimerLimit = Random.Range(SpawnTimeMinimum, SpawnTimeMaximum);
                Car4DespawnTimer = 0;
            }
        }
        
        if (Car1Speed.Forward == true || Car1Speed.Middle == true || Car1Speed.Rear == true)
        {
            Car1DespawnTimer = 0;
        }
        

        if ( Car2Speed.Forward == true || Car2Speed.Middle == true || Car2Speed.Rear == true)
        {
            Car2DespawnTimer = 0;
        }
        

        if (Car3Speed.Forward == true || Car3Speed.Middle == true || Car3Speed.Rear == true)
        {
            Car3DespawnTimer = 0;
        }
        
        if (Car4Speed.Forward == true || Car4Speed.Middle == true || Car4Speed.Rear == true)
        {
            Car4DespawnTimer = 0;
        }
        


        if (Car1.activeInHierarchy == false && Car2.activeInHierarchy == false && Car3.activeInHierarchy == false && Car4.activeInHierarchy == false)
        {
           
            Timer = Timer + Time.deltaTime;
            if( Timer > RandomTimerLimit)
            {
                SpawnNext = true;
            }
        }


       

    }
}
