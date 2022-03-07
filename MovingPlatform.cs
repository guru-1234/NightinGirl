using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public Transform pos1;
    public Transform pos2;
    Vector3 nextPos;
    //private Transform startPos;
    public float speed =3f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=pos1.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position== pos1.position)
        {
            nextPos=pos2.position;
        }
        if(transform.position== pos2.position)
        {
            nextPos=pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position,nextPos,speed*Time.deltaTime);
    }
}
