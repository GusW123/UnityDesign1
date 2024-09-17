using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStartup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("delayAddingScript", 1.5f);
    }

    // Update is called once per frame
    void delayAddingScript()
    {
        gameObject.AddComponent<NavMeshAgent>();
        gameObject.AddComponent<NewEnemyAI>();

        Destroy(GetComponent<Rigidbody>());
    }
}
