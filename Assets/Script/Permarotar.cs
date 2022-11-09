using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Permarotar : MonoBehaviour
{
    public float speedM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speedM * Time.deltaTime, 0);
    }
}
