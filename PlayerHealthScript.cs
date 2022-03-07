using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
   [SerializeField] public static float Health=100f;
    public GameObject PlayerDeathEffect;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        
        Health -=damage;
        if(Health==0)
            {
                PlayerDie();
            }
        Debug.Log(Health);
    }    

    void PlayerDie()
    {
        Instantiate(PlayerDeathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
