using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public Transform position1;
    public Transform position2;
    Vector3 nextPos;
    //public GameObject Gun;
    //private Transform startPos;
    public float speed =0.5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=position1.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position== position1.position)
        {
            nextPos=position2.position;
            transform.Rotate(0f,-180f,0f);

        }
        if(transform.position== position2.position)
        {
            nextPos=position1.position;
            transform.Rotate(0f,180f,0f);
        }

        transform.position = Vector3.MoveTowards(transform.position,nextPos,speed*Time.deltaTime);
    }
}
