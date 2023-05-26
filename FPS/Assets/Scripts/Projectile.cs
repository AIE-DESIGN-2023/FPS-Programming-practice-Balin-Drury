using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Variable for speed, lifetime and damage
    public float speed;
    public float lifeTime;
    public int damage;
    public bool isEnemyBullet;

    //Variable for the RigidBody component and life time Counter
    private Rigidbody rb;
    private float lifeTimeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning the Rigidbody component of the bullet GameObject
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting the velocity of the bullet to match our speed variable
        rb.velocity = transform.forward * speed;

        //Increase our lifetime counter in seconds
        lifeTimeCounter += Time.deltaTime;
        //Check that our lifetime counter >= lifetime
        if(lifeTimeCounter >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    //Unity function that will call when this object collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        if (isEnemyBullet == false)
        {
            //Check if the object we hit is tagged "Enemy"
            if (collision.gameObject.tag == "Enemy")
            {
                //Check that the collision object has an EnemyHealth script
                EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }

            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                }
            }
        }

        //THE LAST THING THAT WE DO IS DESTROY THIS OBJECT!!!!!!!!
        Destroy(this.gameObject);
    }
}
