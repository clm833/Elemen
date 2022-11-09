using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class loadtest : MonoBehaviour
{
    public bool mostrar;
    public string direccion;
    // Start is called before the first frame update
    void Start()
    {
        string Destination = Application.persistentDataPath + direccion;
        FileStream file;
        if (File.Exists(Destination)) file = File.OpenRead(Destination);
        else
        {
            //Debug.Log("no hay archivo vieja");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        mostrar = (bool)bf.Deserialize(file);
        file.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
