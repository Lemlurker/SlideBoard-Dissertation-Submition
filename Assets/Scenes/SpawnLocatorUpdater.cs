using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocatorUpdater : MonoBehaviour
{
    public CarSpawner SpawnScript;
    public int NexSpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            SpawnScript.NextSpawnLocation = NexSpawnLocation;
           // Debug.Log("Checkpoint Collision");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
