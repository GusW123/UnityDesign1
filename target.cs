using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    // Health of the enemy

    public float health = 10f;


    public void TakeDamage(float amount)
    {

        // Remove the damage of the weapon from health

        health -= amount;

        Debug.Log(health);



        // If enemy health is too low, it dies

        if (health <= 0f)
        {

            Die();

        }

       

    }
    void Die()
    {

        Destroy(gameObject);

    }
}
      

