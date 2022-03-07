using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) 
    {
        PlayerHealthScript playerTouch = other.GetComponent<PlayerHealthScript>();
        if(playerTouch!= null)
        {
            playerTouch.TakeDamage(5f);
        }
    }
}
