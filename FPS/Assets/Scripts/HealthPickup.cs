using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int healthPickupAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            //Check player health is less than max
            if(playerHealth.currentHealth < playerHealth.maxHealth)
            {
                //Call into player health script to give health
                playerHealth.TakeDamage(-healthPickupAmount);

                //Destroy the health box
                Destroy(this.gameObject);
            }
            

        }
    }



}
