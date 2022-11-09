using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class savetest : MonoBehaviour
{
    public bool texto;
    public string direccion;
    // Start is called before the first frame update
    void Start()
    {
        string Destination = Application.persistentDataPath + direccion;
        Debug.Log(Destination);
        FileStream file;
        if (File.Exists(Destination)) file = File.OpenWrite(Destination);
        else
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
