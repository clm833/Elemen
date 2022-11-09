using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salidas : MonoBehaviour
{
    //public string scene;
    public int maxllave;
    public int key = 0;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(key);
        if (key >= maxllave)
            SceneManager.LoadScene("elemen 14");
    }



}
