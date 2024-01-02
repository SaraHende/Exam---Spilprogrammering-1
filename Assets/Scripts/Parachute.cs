using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parachute : MonoBehaviour
{
    public float parachuteFallingSpeed = 1.0f;

    private Rigidbody2D rbParachute;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rbParachute.velocity = new Vector2(transform.position.x, transform.position.y * parachuteFallingSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory.noOfParachutes++;
        }
    }
}
