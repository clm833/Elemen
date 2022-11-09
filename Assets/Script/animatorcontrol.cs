using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class animatorcontrol : MonoBehaviour
{
    public Animator anim;
    /*private NavMeshAgent agent;
    public Transform[] destination;
    public int index;*/

    // Start is called before the first frame update
    void Start()
    {
        //anim.SetFloat("speed", 1);
        //anim = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
          anim.Play("New State 0");
        if (Input.GetKeyDown(KeyCode.Space))
             anim.Play("New State");
        /* if (Input.GetKeyDown(KeyCode.Space))
              anim.SetTrigger("Jump");
        if (agent.remainingDistance < 0.2)
        {
            index++;
            index = index % destination.Length;

        }
        agent.SetDestination(destination[index].position);*/
    }
}
