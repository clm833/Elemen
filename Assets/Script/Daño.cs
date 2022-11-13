using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    private float hvida;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("a");
        if (other.GetComponent<Vida>() != null)
        {
            other.GetComponent<Vida>().Restar(hvida);
        }
            
        if (other.gameObject == null) { }
            
    }
    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<Vida>().apag();
    }
}
