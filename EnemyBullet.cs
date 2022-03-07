using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletspeed=5f;
    public Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right *bulletspeed;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerHealthScript player = other.collider.GetComponent<PlayerHealthScript>();
        if(player!= null)
        {
            player.TakeDamage(5f);
        }
        if(other.transform.tag != "Enemy")
        {
            Destroy(gameObject);
        }
        
    }

    
}
