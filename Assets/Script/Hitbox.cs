using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.ToString() + "Mario");
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Vida>()) other.GetComponent<Vida>().dag = true;
    }
   
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Vida>()) other.GetComponent<Vida>().dag = false;
    }
}
