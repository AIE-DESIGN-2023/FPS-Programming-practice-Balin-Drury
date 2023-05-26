using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    //Variable for new bullet prefab
    public GameObject bullet;
    
    
    
    private ProjectileManager projectileManager;


    private void OnTriggerEnter(Collider other)
    {
        //Check to see if it is the player colliding
        if(other.gameObject.tag == "Player")
        {
            //Get the projectile Manager script and reassign the object to instantiate
            other.GetComponent<ProjectileManager>().projectile = bullet;
            
        }
    }

}
