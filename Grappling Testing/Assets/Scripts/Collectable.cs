using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        //Check to see if it is the player colliding
        if (other.tag == "Player")
        {

            //Destroy object and add score
            Debug.Log("It worked!");
            other.GetComponent<PlayerMovement>().AddScore();
            Destroy(this.gameObject);


        }
    }
}
