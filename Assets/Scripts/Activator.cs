using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject Car;
    public GameObject Player;
    public bool Activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Activate == true)
        {
            Car.SetActive(true);
            Player.SetActive(true);
        }
        else
        {
            Car.SetActive(false);
            Player.SetActive(false);
        }
    }
}
