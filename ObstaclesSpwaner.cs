using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpwaner : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private float TimeInfinity = Mathf.NegativeInfinity;
    public float spawnDelay=2f;
    public float DestroyInSeconds=0.5f;
    //public GameObject limit1;
    //public GameObject limit2;
    // Update is called once per frame
    void Update()
    {
        checkspawnertime();
            
    }
    private void checkspawnertime()
    {
        if(Time.timeSinceLevelLoad > TimeInfinity+spawnDelay)
        {
            spawnObstacle();
        }
    }

    private void spawnObstacle()
    {
        GameObject Bump =Instantiate(ObstaclePrefab,transform.position,transform.rotation);
        Destroy(Bump,DestroyInSeconds);
        TimeInfinity =Time.timeSinceLevelLoad;
    }
}
