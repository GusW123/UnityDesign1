using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NewEnemyAI : MonoBehaviour
{
    Transform Player;
    NavMeshAgent agent;



    // Start is called before the first frame update
  void Awake()
   {
       agent = GetComponent<NavMeshAgent>();
        agent.speed = 20f;
        agent.stoppingDistance = 2.5f;

        Player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.position);
    }
}
