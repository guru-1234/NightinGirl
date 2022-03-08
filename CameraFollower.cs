using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform Target;

    void Update()
    {
        
        if(Target !=null)
        {
            transform.position = new Vector3(Target.position.x,Target.position.y,transform.position.z);
        }   
    }
}
