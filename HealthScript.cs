using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] public float Health=100f;
    public GameObject EnemyDeath;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        
        Health -=damage;
            if(Health==0)
            {
                EnemyDie();  
                GameObject Death = Instantiate(EnemyDeath,transform.position,transform.rotation);
                Destroy(Death,.5f);
            }
        
    }    

    void EnemyDie()
    {
        Destroy(gameObject);  
    }
            
}
