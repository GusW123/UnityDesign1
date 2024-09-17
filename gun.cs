/*
 * using System;
using UnityEngine;
public class gun : MonoBehaviour
{
    void Awake()

    {
        controls = new CharacterInput();
    }


    void OnEnable()

    {
        controls.Enable();
    }


    void OnDisable()

    {
        controls.Disable();
    }

    private CharacterInput controls;

    public float damage = 10f; // How much damage our gun causes

    public float range = 10f; // How far we can shoot

    //public Camera fpsCam;
    public bool shoot;
    public Transform player; // The player's transform
    public Camera playerCam; // The player's camera, if you need it for any reason


    // Update is called once per frame
    void Update()
    {
        if (controls.Player.Shoot.triggered)
        {
        
            Shoot();
            // Check our controller to see if we have pressed the fire button

            /*  while (controls.Player.Shoot.triggered)
              {
                  Shoot();

                  WaitForSeconds(0.5f);
              }
              
            //  if (Input.GetMouseButtonDown(0))
            //   {
            //      shoot = true;
            //  }
            /// else if (Input.GetMouseButtonUp(0))
            //  {
            //      shoot = false;
            //  }
            //  else (shoot == true);
            //  {
            //      Shoot();
            //   }


        }
    }

    private void WaitForSeconds(float v)
    {
        throw new NotImplementedException();
    }

    void Shoot()
    {

        // Define a raycast hit object

        RaycastHit hit;

        //Shoot the ray from the camera's position and rotation for the distance in the range

        // this will return a true / false value and the object info of what we hit in "hit"
       
        if (Physics.Raycast(player.position, player.forward, out hit, range))
        {
            // if we hit something, print it to the debug log

            Debug.Log(hit.transform.name);


            target enemy = hit.transform.GetComponent<target>();

            if (enemy != null)
            {

                enemy.TakeDamage(damage);

            }
        }
    }
}
*/
/*
using UnityEngine;
using System;
public class Gun : MonoBehaviour
{
    private CharacterInput controls;

    public float damage = 10f; // How much damage our gun causes
    public float range = 10f; // How far we can shoot
    public Transform player; // The player's transform
    public Camera playerCam; // The player's camera, if you need it for any reason

    void Awake()
    {
        controls = new CharacterInput();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        if (controls.Player.Shoot.triggered)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        // Shoot the ray from the player's position and forward direction
        if (Physics.Raycast(player.position, player.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target enemy = hit.transform.GetComponent<target>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
*/
using System;
using UnityEngine;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private CharacterInput controls;

    public float damage = 10f; // How much damage our gun causes
    public float range = 10f; // How far we can shoot
    public Transform player; // The player's transform
    public float fireRate = 0.1f; // Time between shots

    private float nextFireTime = 0f;

    void Awake()
    {
        controls = new CharacterInput();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        // Check if the shoot action is triggered and if the fire rate allows it
        if (controls.Player.Shoot.ReadValue<float>() > 0.01f) // Adjust threshold if needed
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        // Shoot the ray from the player's position and forward direction
        if (Physics.Raycast(player.position, player.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target enemy = hit.transform.GetComponent<target>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
