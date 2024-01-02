using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    private Rigidbody2D rbDagger;
    private Inventory inventory;

    public float daggerSpeed = 10f;
    
    private void Awake()
    {
        rbDagger = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        rbDagger.velocity = transform.right * daggerSpeed;
        //Rigidbody controls velocity. Tells the dagger to move forward by "daggerSpeed" continously.
    }
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Picked up dagger");
            
            //inventory.noOfDaggers++; //Increase no. of daggers in Inventory.
      

            //Make Dagger a child of player.
                //Code
            //Set gameObject to false.
            gameObject.SetActive(false);
        }
        
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + collision.name);
            //Enemy dies.
            Enemy enemy = collision.GetComponent<Enemy>(); //Collision with an object that has the Enemy script attached to it.
            if (enemy != null) //If enemy is not null, then trigger function.
            {
                enemy.HitByDagger(); //Function in Enemy script. 
            }
            //Destroys the dagger
            Destroy(gameObject);
        }

    }


}
