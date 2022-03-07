using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject EnemyBullet;
    private float TimeInfinity = Mathf.NegativeInfinity;
    public float spawnDelay=2f;
    public Transform Gun;
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
            spawnBullet();
        }
    }

    private void spawnBullet()
    {
        GameObject bullet =Instantiate(EnemyBullet,Gun.position,Gun.rotation);
        Destroy(bullet,DestroyInSeconds);
        TimeInfinity =Time.timeSinceLevelLoad;
    }
}
