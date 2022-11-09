using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DohNDie : MonoBehaviour
{
    public float amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0.3f,0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Vida>() != null)
        {
            other.GetComponent<Vida>().HoD(amount);
            Destroy(gameObject);
        } 
    }
}
