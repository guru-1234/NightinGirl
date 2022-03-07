using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespwanFollwer : MonoBehaviour
{

    [SerializeField] private GameObject Player;


    // Start is called before the first frame update
    // Update is called once per frame
    void Update() {

        if(Player!=null)
        {
            gameObject.transform.position = new Vector3(Player.transform.position.x,transform.position.y,transform.position.z);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D spawn) 
    {
        PlayerHealthScript Health = spawn.GetComponent<PlayerHealthScript>();
        if(Player!=null)
        {
            if(spawn.CompareTag("Player"))
            {
                Health.TakeDamage(10f);
                Player.transform.position = CheckPoint.pointupdate;
            }else{
                Player.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z);
            }
        }
        
    }

}
