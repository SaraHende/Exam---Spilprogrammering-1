using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 1;

    public void HitByDagger()
    {
        Debug.Log("Enemy dead");
        enemyHealth = 0;
        //Play death animation. Enemy stays onscreen until it passes the body.
        //CODE
        //Invoke/Coroutine? (Destroy(gameObject) when camera has moved past it.
        //Code

        Destroy(gameObject); //Will destroy the enemy for now
    }

}
