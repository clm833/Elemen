using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class savetestlocal : MonoBehaviour
{
    public string direccion;
    public string texto;
    // Start is called before the first frame update
    void Awake()
    {
        string Destination =  direccion;
        Debug.Log(Destination);
        FileStream file;
      
            file = File.Create(Destination);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, texto);
        file.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
