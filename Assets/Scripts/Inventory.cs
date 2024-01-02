using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int noOfParachutes;
    public int noOfDaggers;

    //No. of items in inventory
    public TMP_Text textParachute;
    public Image imageParachute;
    public TMP_Text textDagger;
    public Image imageDagger;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //Inventory information
        textParachute.text = "Hello"; 
        noOfDaggers = 0;

    }

    private void Update()
    {
       
    }

}
