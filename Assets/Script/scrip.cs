using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scrip : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform destination;
   // public int index;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        agent.SetDestination(destination.position);
    }

    public void parar()
    {
        agent.speed = 0;
        agent.acceleration = 0;
        agent.angularSpeed = 0;
    }
}
