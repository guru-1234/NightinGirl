using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static Vector3 pointupdate;
    // Start is called before the first frame update
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.transform.tag == "Player")
        {
           
            pointupdate = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        }
    }
}
