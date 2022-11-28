using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage;


    private void OnTriggerEnter(Collider other)
    {
        
        PlayerMain playerMain;
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hit the player with enter");
            playerMain = other.gameObject.GetComponentInChildren<PlayerMain>();
            playerMain.TakeDamage(damage);
        }
    }
}
