using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Test : MonoBehaviour
{
    public static Test instance;

    public GameObject otherGameObject;

    public int[] arrayOfIntegers = new int[2];
    public int i = 0;
    public InputMaster controller;
    public int[] array = { 1, 2, 4, 6 };
    public bool isTrue = true;

    public int number = 1;
    public string word = "Hello";
    public bool test = true;

    public int anotherNumber = 2;

    public int x = 3;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != null)
            Destroy(gameObject);


        otherGameObject.GetComponent<Rigidbody2D>();

        controller = new InputMaster();


        arrayOfIntegers[0] = 1;

        Debug.Log(arrayOfIntegers[0]);


        arrayOfIntegers[i] = 2;
        Debug.Log(arrayOfIntegers[i]);

    }

    private void FixedUpdate()
    {
       
        for (i = 0; i < array.Length; i++)
        {
	        Debug.Log(array[i]);
        }


        //Example of if statement:
        if (isTrue)
        {
            Debug.Log("Print message");
        }

        //Example of boolean operation "And" = &&.
        if (number == 1 && word == "Hello")
        {
            Debug.Log("The statement is true");
        }

        //Example of boolean operation "Or" = ||.
        if (number > 2 || test == true)
        {
            Debug.Log("Statement is true");
        }

        //Example of boolean operation "Not" = !.
        if (number == 1 && test != true)
        {
            Debug.Log("This message will not be printed");
        }

        //Example of a loop:
        //anotherNumber has been initialized as 2.
        while (anotherNumber == 2)
        {
        Debug.Log("anotherNumber");
        }

        //Example of Invoke:
        Invoke("ReturnInts", 3f);

        

    }






    //Example of a general function
    /*<acess modifier> <return type> <name of function> (parameters)
    {Block of code that is executed}*/
    public int ReturnInts(int x)
        { return x; }
}

   /* private void Teleportation(InputAction.CallbackContext context)
    {

        throw new NotImplementedException();
    }

    private void OnEnable() //This happens when the game object is activated.
    {
        controller.Enable(); //Gets "InputMaster" -> Turns on inputs.
        controller.Player.Teleportation.performed += Teleportation;

    }

    private void OnDisable() //This happens when the game object is disabled.
    {
        controller.Disable(); //Makes InputMaster = null -> Turns off inputs.

    }*/



