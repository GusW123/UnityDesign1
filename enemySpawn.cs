using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;



public class enemySpawn : MonoBehaviour
{
    public int numEnemies = 1; //How many enemies we want

    public GameObject prefab; // The Prefab we want to spawn

    int originalChildren; // How many children did we have originally

    Transform enemies; // Holds the parent object

    Random rand = new Random(); // New random to randomise the location of the enemies


    void makeAChild()
    {
        // Grab some random coordinates

        float childX = rand.Next(50);

        float childZ = rand.Next(50);
        // Make a new gameobject, instantiate a copy of the prefab at the location we randomised

        GameObject newChild = Instantiate(prefab, new Vector3(childX, 10f, childZ), Quaternion.identity) as GameObject;



        // Set the parent of the enemy to be the Enemies game object

        newChild.transform.parent = enemies;

    }



        // Start is called before the first frame update
        void Start()
    {

        enemies = GameObject.Find("Enemies").transform;



        // At the start, spawn all the children

        for (int i = 0; i < numEnemies; i++)
        {

            makeAChild();

        }

        // Count how many children there are

        originalChildren = transform.childCount;


    }

    // Update is called once per frame
    void Update()
    {

        // Get the current number of enemies

        int currentChildren = transform.childCount;



        // if there are less enemies than there were originally, make another

        if (currentChildren < originalChildren)
        {

            makeAChild();

        }

    }
}
