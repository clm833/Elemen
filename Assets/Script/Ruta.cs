using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ruta : MonoBehaviour
{
    private NavMeshAgent pato;
    public Transform[] destino;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        pato = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pato.remainingDistance < 0.2)
        {
            index++;
            index = index % destino.Length;
        }
            pato.SetDestination(destino[index].position);
    }
}
