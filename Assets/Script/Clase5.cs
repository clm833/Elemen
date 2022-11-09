using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase5 : MonoBehaviour
{
    public GameObject Bala;
    // Start is called before the first frame update
    void Start()
    {
        Invoke ("Disparar", 2);
        //InvokeRepeating("Disparar", 3, 1);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Disparar()
    {
    Instantiate (Bala, transform.position, transform.rotation);
    Invoke("Disparar", 2);
    }

}
