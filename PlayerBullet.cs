using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float PlayerBulletspeed=50f;
    public Rigidbody2D rbBullet; 
    public GameObject ShotPrefab;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet.velocity = transform.right *PlayerBulletspeed;
    }

    void OnTriggerEnter2D(Collider2D Bullet)
    {
        HealthScript Enemy = Bullet.GetComponent<HealthScript>();
        if(Enemy!=null)
        {
            Enemy.TakeDamage(20f);
        }
        if(Bullet.transform.tag != "CheckPoint")
        {
            Destroy(gameObject);
            GameObject BulletFreab = Instantiate(ShotPrefab,transform.position,transform.rotation);
            Destroy(BulletFreab,0.3f);
        }
        
    }

}
