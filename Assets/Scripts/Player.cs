using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    //THINGS THAT NEED TO BE IMPLEMENTED
    //Melee attacks. 

    //BUGS:
    /*Continously moving. - Why? Is it the calculations in the move function? Removed fixed update; am I supposed to do that?
     *Does teleport work? - Need to disable sprite renderer and enable it again*/

    private InputMaster controller;
    private Vector2 move;
    private Rigidbody2D rb2D;
    private bool sliding = false; //Checks if the player is sliding.
    private Vector2 teleportPosition;
    private bool facingRight;
    private int noOfJumps = 2;

    private Rigidbody2D rbDagger;

    public float moveSpeed = 5f;
    public float maxSlideTime = 0.5f; //Maximum time of duration of slide.
    public float jumpForce = 2f;
    public float teleportDistance = 2f;
    public bool isGrounded;
    public int flowers;

    public Transform firePoint;
    public GameObject DaggerPrefab;
    public Transform parachutePoint;
    public GameObject ParachutePrefab;

    private void Awake()
    {
        controller = new InputMaster(); //Creating a new object of type InputMaster.
        rb2D = GetComponent<Rigidbody2D>(); //Referencing rigidbody on gameObject.

    //Referencing/activating actions in InputMaster.
        //controller.Player.Slide.performed += c => Slide(); //"<Name of InputActionAsset>.<Name of action map>.<Name of action>.performed" = Has the input relating to the action been pressed?
        controller.Player.Slide.performed += c => StartCoroutine(Slide()); //Starts coroutine when input is registered.
        //controller.Player.Teleportation.performed += leftShift => Teleportation();
        //controller.Player.Movement.performed += moveAxis => Movement(moveAxis.ReadValue<Vector2>()); //Reads the input value as a Vector2.
        controller.Player.Jump.performed += w => Jump();
        controller.Player.Throw.performed += g => ThrowDagger();
        controller.Player.Parachute.performed += d => Parachute();
    }


    private void FixedUpdate()
    {
        Movement(controller.Player.Movement.ReadValue<Vector2>());
    }

    

    /*private void Teleportation()
    {
        Debug.Log("Teleport");

        teleporting = true;
        if (teleporting == true)
        teleportPosition = new Vector2(teleportDistance, 0);

        gameObject.transform.position = teleportPosition;

        teleporting = false;

        
    }*/

    /*void Slide()
    {
        Debug.Log("Slide");
        gameObject.transform.localScale = new Vector3(0.5f ,0.5f ,0.5f); 
        
        sliding = true;
        Debug.Log("Is sliding true?");
        if (sliding == true)
        {
            Invoke("ResetSlideTimer", maxSlideTime);

            Debug.Log("Yes");

        }
    }*/

     IEnumerator Slide()
    {
        Debug.Log("Slide");
        
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); //Halves the scale of the player.

        sliding = true;
        Debug.Log("Is sliding true?");
        if (sliding == true)
        {
            yield return new WaitForSeconds(maxSlideTime); //Special feature of coroutines. Pauses the code for "maxSlideTime" seconds. 
            //Then continues the code.

            Debug.Log("Success");
            sliding = false;

            gameObject.transform.localScale = new Vector3(1, 1, 1); //Returns scaling to normal.

        }
    }

    /*void ResetSlideTimer()
    {
        Debug.Log("Success");

        sliding = false; 
        
        gameObject.transform.localScale = new Vector3(1, 1, 1); //Returns scaling to normal.
        
    }*/

    void Movement(Vector2 direction)
    {
        move = direction;
        //rb2D.velocity = move * moveSpeed;
        rb2D.velocity = new Vector2(move.x * moveSpeed, rb2D.velocity.y); //Movement on x-axis, 'implements' gravity, no upwards movement. 
        Debug.Log("I'm moving" + direction);

        //Flip();


    }

    void Jump()
    {
        isGrounded = true;
        if(isGrounded == true && flowers == 0 && noOfJumps == 2)
        {
            Debug.Log("Single jump");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            noOfJumps--;
        }
        else if (isGrounded == false && flowers > 0 && noOfJumps == 1) 
        {
            Debug.Log("Double jump");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            noOfJumps--;
            noOfJumps = 2;
        }
        
    }

    private void ThrowDagger()
    {
        Debug.Log("Dagger thrown");
        Instantiate(DaggerPrefab, firePoint.position, firePoint.rotation);
        //needs the object, spawn position and spawn rotation.
        //This makes sure the dagger spawns at the FirePoint created attached to the Player.
        
    }

    //Parachute
    private void Parachute()
    {
        Debug.Log("Parachute");
        Instantiate(ParachutePrefab, parachutePoint.position, parachutePoint.rotation);
        //Parachute does not follow, should it be instantiated as a child to Player?
    }


    //NON-MECHANICS
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }


    private void OnEnable() //This happens when the game object is activated.
    {
        controller.Enable(); //Gets "InputMaster" -> Turns on inputs.
      
    }

    private void OnDisable() //This happens when the game object is disabled.
    {
        controller.Disable(); //Makes InputMaster = null -> Turns off inputs.

    }

   



}
