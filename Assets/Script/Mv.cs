using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mv : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        InvokeRepeating("PMover", 5, 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    private void PMover()
    {
        speed = speed * -1;
    }
}
